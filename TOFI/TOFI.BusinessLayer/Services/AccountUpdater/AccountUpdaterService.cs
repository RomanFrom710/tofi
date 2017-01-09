using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Result;
using DAL.Repositories.Common.Price;
using DAL.Repositories.Credits.CreditAccount;
using DAL.Repositories.Credits.CreditAccountState;
using NLog;
using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;
using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.AccountUpdater
{
    public class AccountUpdaterService : Service
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly CreditAccountQueryRepository _creditAccountQueryRepository;
        private readonly CreditAccountCommandRepository _creditAccountCommandRepository;
        private readonly CreditAccountStateQueryRepository _creditAccountStateQueryRepository;
        private readonly CreditAccountStateCommandRepository _creditAccountStateCommandRepository;
        private readonly PriceCommandRepository _priceCommandRepository;

        public AccountUpdaterService(CreditAccountQueryRepository creditAccountQueryRepository,
            CreditAccountCommandRepository creditAccountCommandRepository,
            CreditAccountStateQueryRepository creditAccountStateQueryRepository,
            CreditAccountStateCommandRepository creditAccountStateCommandRepository,
            PriceCommandRepository priceCommandRepository)
        {
            _creditAccountQueryRepository = creditAccountQueryRepository;
            _creditAccountCommandRepository = creditAccountCommandRepository;
            _creditAccountStateQueryRepository = creditAccountStateQueryRepository;
            _creditAccountStateCommandRepository = creditAccountStateCommandRepository;
            _priceCommandRepository = priceCommandRepository;
        }

        public ServiceResult UpdateAccounts(DateTime specifiedDate)
        {
            try
            {
                Logger.Info("UpdateAccounts called");
                UpdateAccountsInternal(specifiedDate);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Failed to update accounts: {ex.Message}");
                return new ServiceResult(false).Error($"Failed to update accounts: {ex.Message}", ex);
            }
            return new ServiceResult(true);
        }

        public ServiceResult UpdateAccount(int creditAccountId, DateTime specifiedDate)
        {
            try
            {
                Logger.Info("UpdateAccounts called");
                UpdateAccount(creditAccountId, specifiedDate);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Failed to update accounts: {ex.Message}");
                return new ServiceResult(false).Error($"Failed to update accounts: {ex.Message}", ex);
            }
            return new ServiceResult(true);
        }

        private void UpdateAccountInternal(int creditAccountId, DateTime specifiedDate)
        {
            var newCreditAccountState = UpdateFinesAndGetAccountState(creditAccountId, specifiedDate);
            if (newCreditAccountState != null)
            {
                var createModelCommand = new CreateModelCommand<CreditAccountStateDto>()
                {
                    ModelDto = newCreditAccountState
                };
                _creditAccountStateCommandRepository.Execute(createModelCommand);
            }
        }

        #region Private Methods

        private CreditAccountStateDto UpdateFinesAndGetAccountState(int creditAccountId, DateTime specifiedDate)
        {
            var query = new ModelQuery()
            {
                Id = creditAccountId
            };
            var account = _creditAccountQueryRepository.Handle(query);
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
                finesForOverdue.Value += account.CreditType.FineInterest *
                                         latestCreditAccountState.MainDebtRemain.Value;
                var updateFinesCommand = new UpdateModelCommand<PriceDto>()
                {
                    ModelDto = finesForOverdue
                };
                _priceCommandRepository.Execute(updateFinesCommand);
            }
            if (ShouldAccountUpdate(account, specifiedDate))
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
                else if (sumPaidForLatestPeriod <
                         debtForMonth + mainDebtRemain + totalInterestNotPaid + interestForMonth)
                {
                    newTotalDebtRemaining -= debtForMonth + mainDebtRemain;
                    newTotalInterestNotPaid += interestForMonth -
                                               (sumPaidForLatestPeriod - debtForMonth - mainDebtRemain);
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
                return newCreditAccountState;
            }
            return null;
        }

        private void UpdateAccountsInternal(DateTime specifiedDate)
        {
            var query = new AllModelsQuery();
            var accounts = _creditAccountQueryRepository.Handle(query);
            var creditAccountsStates = new List<CreditAccountStateDto>();
            foreach (var account in accounts)
            {
                var newCreditAccountState = UpdateFinesAndGetAccountState(account.Id, specifiedDate);
                if (newCreditAccountState != null)
                {
                    creditAccountsStates.Add(newCreditAccountState);
                }
            }
            foreach (var state in creditAccountsStates.ToList())
            {
                var createModelCommand = new CreateModelCommand<CreditAccountStateDto>()
                {
                    ModelDto = state
                };
                _creditAccountStateCommandRepository.Execute(createModelCommand);
            }
        }

        private static bool ShouldAccountUpdate(CreditAccountDto account, DateTime today)
        {
            return account.AgreementDate.Date != today && account.AgreementDate.Day == today.Day;
        }

        private static decimal GetDebtForMonth(CreditAccountStateDto accountState)
        {
            var totalDebtRemaining = accountState.RemainDebt.Value;
            return totalDebtRemaining / (accountState.CreditAccount.TotalMonthDuration - accountState.Month);
        }

        #endregion
    }
}
