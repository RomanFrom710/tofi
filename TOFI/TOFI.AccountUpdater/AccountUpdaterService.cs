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
using DAL.Repositories.Credits.CreditAccountState;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;
using DAL.Repositories.Common.Price;

namespace TOFI.AccountUpdater
{
    public class AccountUpdaterService
    {
        private readonly Logger Logger;
        private readonly CreditAccountQueryRepository _creditAccountQueryRepository;
        private readonly CreditAccountCommandRepository _creditAccountCommandRepository;
        private readonly CreditAccountStateQueryRepository _creditAccountStateQueryRepository;
        private readonly CreditAccountStateCommandRepository _creditAccountStateCommandRepository;
        private readonly PriceCommandRepository _priceCommandRepository;

        public AccountUpdaterService()
        {
            Logger = LogManager.GetCurrentClassLogger(); 
            var context = new TofiContext();
            _creditAccountCommandRepository = new CreditAccountCommandRepository(context);
            _creditAccountQueryRepository = new CreditAccountQueryRepository(context);
            _creditAccountStateCommandRepository = new CreditAccountStateCommandRepository(context);
            _creditAccountStateQueryRepository = new CreditAccountStateQueryRepository(context);
            _priceCommandRepository = new PriceCommandRepository(context);
        }
        
        public void UpdateAccounts()
        {
            Logger.Info("UpdateAccounts called");
            var query = new AllModelsQuery();
            var accounts = _creditAccountQueryRepository.Handle(query);
            var creditAccountsStates = new List<CreditAccountStateDto>();
            foreach (var account in accounts)
            {
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
                var accountPayments = _creditAccountQueryRepository.Handle(creditAccountPaymentsQuery);
                var paymentsForLatestPeriod = accountPayments.Where(p => latestCreditAccountStateDate < p.Timestamp);

                // S
                var sumPaidForLatestPeriod = paymentsForLatestPeriod.Sum(p => p.PaymentSum.Value);
                // Z
                var totalDebtRemaining = latestCreditAccountState.RemainDebt.Value;
                // A
                var debtForMonth = GetDebtForMonth(latestCreditAccountState);
                if (latestCreditAccountState.MainDebtRemain.Value > sumPaidForLatestPeriod)
                {
                    var finesForOverdue = latestCreditAccountState.FinesForOverdue;
                    finesForOverdue.Value += account.CreditType.FineInterest * latestCreditAccountState.MainDebtRemain.Value;
                    var updateFinesCommand = new UpdateModelCommand<PriceDto>()
                    {
                        ModelDto = finesForOverdue
                    };
                    _priceCommandRepository.Execute(updateFinesCommand);                    
                }
                if (ShouldAccountUpdate(account))
                {
                    var previousFinesForOverdue = latestCreditAccountState.FinesForOverdue;
                    var accountCurrency = account.Currency;
                    
                    
                    // B
                    var interestForMonth = (decimal)account.CreditType.InterestRate / 12 * totalDebtRemaining;
                    var totalInterestNotPaid = latestCreditAccountState.TotalInterestSumNotPaid.Value;

                    var newTotalDebtRemaining = totalDebtRemaining;
                    var newTotalInterestNotPaid = totalInterestNotPaid;
                    var mainDebtRemain = latestCreditAccountState.MainDebtRemain.Value;
                    if (sumPaidForLatestPeriod < debtForMonth + mainDebtRemain)
                    {
                        newTotalDebtRemaining -= sumPaidForLatestPeriod;
                        newTotalDebtRemaining += debtForMonth;
                        newTotalInterestNotPaid += interestForMonth;
                        mainDebtRemain = debtForMonth + mainDebtRemain - sumPaidForLatestPeriod;
                    }
                    else if (sumPaidForLatestPeriod < debtForMonth + mainDebtRemain + totalInterestNotPaid + interestForMonth)
                    {
                        newTotalDebtRemaining -= debtForMonth + mainDebtRemain;
                        newTotalInterestNotPaid += interestForMonth - (sumPaidForLatestPeriod - debtForMonth - mainDebtRemain);
                        mainDebtRemain = 0m;
                    }
                    else
                    {
                        newTotalInterestNotPaid = 0m;
                        newTotalDebtRemaining -= sumPaidForLatestPeriod - interestForMonth - totalInterestNotPaid;
                        mainDebtRemain = 0m;
                    }

                    var newCreditAccountState = new CreditAccountStateDto()
                    {
                        CreditAccount = account,
                        Month = latestCreditAccountState.Month + 1,
                        FinesForOverdue = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = previousFinesForOverdue.Value
                        },
                        InterestCounted = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = interestForMonth
                        },
                        RemainDebt = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = newTotalDebtRemaining + previousFinesForOverdue.Value   
                        },
                        TotalInterestSumNotPaid = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = newTotalInterestNotPaid
                        },
                        MainDebtRemain = new PriceDto()
                        {
                            Currency = accountCurrency,
                            Value = mainDebtRemain
                        }
                    };
                    creditAccountsStates.Add(newCreditAccountState);
                }
            }
            foreach(var state in creditAccountsStates.ToList())
            {
                var createModelCommand = new CreateModelCommand<CreditAccountStateDto>()
                {
                    ModelDto = state
                };
                _creditAccountStateCommandRepository.Execute(createModelCommand);
            }
        }

        #region Private Methods

        private static bool ShouldAccountUpdate(CreditAccountDto account)
        {
            return account.AgreementDate != DateTime.Today && account.AgreementDate.Day == DateTime.Now.Day;
        }

        private static decimal GetDebtForMonth(CreditAccountStateDto accountState)
        {
            var totalDebtRemaining = accountState.RemainDebt.Value;
            return totalDebtRemaining / (accountState.CreditAccount.TotalMonthDuration - accountState.Month);
        }

        #endregion
    }
}
