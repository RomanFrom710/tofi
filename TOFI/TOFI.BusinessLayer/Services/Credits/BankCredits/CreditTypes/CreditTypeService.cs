using System;
using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.BankCredits.CreditTypes;
using System.Linq;
using BLL.Result;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditTypes
{
    public class CreditTypeService : ModelService<CreditTypeDto, CreditTypeViewModel>, ICreditTypeService
    {
        private readonly ICreditTypeQueryRepository _queryRepository;
        private readonly ICreditTypeCommandRepository _commandRepository;


        public CreditTypeService(ICreditTypeQueryRepository queryRepository,
            ICreditTypeCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public decimal MinMonthPayment(SelectCreditTypesQuery query, CreditTypeViewModel creditType)
        {
            return creditType.CreditConditions.Where(c => c.MinCreditSum.Currency.Id == query.CreditSumCurrencyId)
            .Min(cond => GetMinMonthPaymentForCondition(creditType, cond));
        }

        public decimal MaxMonthPayment(SelectCreditTypesQuery query, CreditTypeViewModel creditType)
        {
            return creditType.CreditConditions.Where(c => c.MaxCreditSum.Currency.Id == query.CreditSumCurrencyId)
            .Max(cond => GetMaxMonthPaymentForCondition(creditType, cond));
        }

        public decimal GetAveragePayment(SelectCreditTypesQuery query, CreditTypeViewModel creditType)
        {
            var debt = query.CreditSumValue / query.MonthDuration;
            var interest = (decimal)creditType.InterestRate / 12 * query.CreditSumValue;
            return debt + interest;
        }

        public ValueResult<bool> ValidateCredit(CreditTypeViewModel creditType)
        {
            try
            {
                return new ValueResult<bool>(ValidateCreditInternal(creditType), true);
            }
            catch (Exception ex)
            {
                return new ValueResult<bool>(false, false).Error(ex.Message, ex);
            }
        }


        private decimal GetMinMonthPaymentForCondition(CreditTypeViewModel creditType, CreditConditionViewModel creditCondition)
        {
            var debt = creditCondition.MinCreditSum.Value / creditCondition.MonthDurationTo;
            var interest = (decimal) creditType.InterestRate / 12 * creditCondition.MinCreditSum.Value;
            return debt + interest;
        }

        private decimal GetMaxMonthPaymentForCondition(CreditTypeViewModel creditType, CreditConditionViewModel creditCondition)
        {
            var debt = creditCondition.MaxCreditSum.Value / creditCondition.MonthDurationFrom;
            var interest = (decimal)creditType.InterestRate / 12 * creditCondition.MaxCreditSum.Value;
            return debt + interest;
        }

        private bool ValidateCreditInternal(CreditTypeViewModel creditType)
        {
            if (creditType.FineInterest >= 100 || creditType.FineInterest <= 0)
                return false;
            if (creditType.InterestRate >= 100 || creditType.InterestRate <= 0)
                return false;
            foreach (var condition in creditType.CreditConditions)
            {
                if (condition.MonthDurationTo < 0 || condition.MonthDurationFrom < 0 ||
                    condition.MonthDurationFrom > condition.MonthDurationTo)
                    return false;
                if (condition.MinCreditSum.Value < 0 || condition.MaxCreditSum.Value < 0 ||
                    condition.MinCreditSum.Value > condition.MaxCreditSum.Value ||
                    condition.MinCreditSum.Currency.Id != condition.MaxCreditSum.Currency.Id)
                    return false;
            }
            creditType.InterestRate /= 100.0;
            creditType.FineInterest /= 100.0m;
            return true;
        }
    }
}