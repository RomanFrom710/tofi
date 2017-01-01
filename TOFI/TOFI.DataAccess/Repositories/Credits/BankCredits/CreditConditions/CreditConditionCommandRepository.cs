using DAL.Contexts;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.CreditConditions
{
    public class CreditConditionCommandRepository : ModelCommandRepository<CreditConditionModel, CreditConditionDto>, ICreditConditionCommandRepository
    {
        public CreditConditionCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(CreditConditionModel model, CreditConditionDto modelDto)
        {
            model.MinCreditSum.Currency = GetCurrencyModel(modelDto.MinCreditSum.Currency?.Id);
            model.MaxCreditSum.Currency = GetCurrencyModel(modelDto.MaxCreditSum.Currency?.Id);
        }
    }
}