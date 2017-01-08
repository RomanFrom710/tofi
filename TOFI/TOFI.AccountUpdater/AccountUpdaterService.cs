using DAL.Repositories.Credits.CreditAccount;
using TOFI.TransferObjects.Model.Queries;
using DAL.Contexts;
using NLog;
using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using System.Linq;
using System;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Common.Price.DataObjects;
using System.Collections.Generic;

namespace TOFI.AccountUpdater
{
    public class AccountUpdaterService
    {
        private readonly Logger Logger;
        private readonly CreditAccountQueryRepository _creditAccountQueryRepository;
        private readonly CreditAccountCommandRepository _creditAccountCommandRepository;
        private readonly CreditAccountStateQueryRepository _creditAccountStateQueryRepository;
        private readonly CreditAccountStateCommandRepository _creditAccountStateCommandRepository;

        public AccountUpdaterService()
        {
            Logger = LogManager.GetCurrentClassLogger(); 
            var context = new TofiContext();
            _creditAccountCommandRepository = new CreditAccountCommandRepository(context);
            _creditAccountQueryRepository = new CreditAccountQueryRepository(context);
            _creditAccountStateCommandRepository = new CreditAccountStateCommandRepository(context);
            _creditAccountStateQueryRepository = new CreditAccountStateQueryRepository(context);
        }
        
        public void UpdateAccounts()
        {
            Logger.Info("UpdateAccounts called");
            var query = new AllModelsQuery();
            var accounts = _creditAccountQueryRepository.Handle(query);
            var creditAccountsStates = new List<CreditAccountStateDto>();
            foreach (var account in accounts)
            {
                if (ShouldAccountUpdate(account))
                {
                    var accountCurrency = account.Currency;
                    var latestCreditAccountStateQuery = new ActualCreditAccountStateQuery()
                    {
                        CreditAccountId = account.Id
                    };
                    var latestCreditAccountState = _creditAccountQueryRepository.Handle(latestCreditAccountStateQuery);
                    var creditAccountPaymentsQuery = new CreditPaymentsQuery()
                    {
                        CreditAccountId = account.Id
                    };
                    var latestCreditAccountStateDate = account.AgreementDate.AddMonths(latestCreditAccountState.Month);
                    var paymentsForLatestPeriod = _creditAccountQueryRepository.Handle(creditAccountPaymentsQuery).Where(p => latestCreditAccountStateDate < p.Timestamp);
                    // S
                    var sumPaidForLatestPeriod = paymentsForLatestPeriod.Sum(p => p.PaymentSum.Value);
                    // Z
                    var totalDebtRemaining = latestCreditAccountState.RemainDebt.Value;
                    // A
                    var debtForMonth = totalDebtRemaining / (account.TotalMonthDuration - latestCreditAccountState.Month);
                    // B
                    var interestForMonth = (decimal)account.CreditType.InterestRate / 12 * totalDebtRemaining;
                    var totalInterestNotPaid = latestCreditAccountState.TotalInterestSumNotPaid.Value;

                    var finesForOverdue = 0m;
                    var newTotalDebtRemaining = totalDebtRemaining;
                    var newTotalInterestNotPaid = totalInterestNotPaid;
                    if (sumPaidForLatestPeriod < debtForMonth)
                    {
                        finesForOverdue = account.CreditType.FineInterest * (debtForMonth - sumPaidForLatestPeriod);
                        newTotalDebtRemaining -= sumPaidForLatestPeriod;
                        newTotalInterestNotPaid += interestForMonth;
                    }
                    else if (sumPaidForLatestPeriod < debtForMonth + totalInterestNotPaid + interestForMonth)
                    {
                        newTotalDebtRemaining -= debtForMonth;
                        newTotalInterestNotPaid += interestForMonth - (sumPaidForLatestPeriod - debtForMonth);
                    }
                    else
                    {
                        newTotalInterestNotPaid = 0m;
                        newTotalDebtRemaining -= sumPaidForLatestPeriod - interestForMonth - totalInterestNotPaid;
                    }

                    var newCreditAccountState = new CreditAccountStateDto()
                    {
                        CreditAccount = account,
                        Month = latestCreditAccountState.Month + 1,
                        FinesForOverdue = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = finesForOverdue
                        },
                        InterestCounted = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = interestForMonth
                        },
                        RemainDebt = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = newTotalDebtRemaining + finesForOverdue
                        },
                        TotalInterestSumNotPaid = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = newTotalInterestNotPaid
                        }
                    };
                    creditAccountsStates.Add(newCreditAccountState);
                }
            }

            var updateModelsCommand = new UpdateModelsCommand<CreditAccountStateDto>()
            {
                ModelsDto = creditAccountsStates.ToList()
            };
            _creditAccountStateCommandRepository.Execute(updateModelsCommand);
        }

        #region Private Methods

        private static bool ShouldAccountUpdate(CreditAccountDto account)
        {
            return account.AgreementDate.Day == DateTime.Now.Day;
        }

        #endregion
    }
}
