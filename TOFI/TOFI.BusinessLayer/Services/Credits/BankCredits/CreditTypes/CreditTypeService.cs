using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.BankCredits.CreditTypes;
using System.Linq;
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
    }
}