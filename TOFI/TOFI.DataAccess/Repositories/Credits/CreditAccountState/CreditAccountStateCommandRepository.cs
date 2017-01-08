using DAL.Contexts;
using DAL.Models.Credits.CreditAccount;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;

namespace DAL.Repositories.Credits.CreditAccountState
{
    public class CreditAccountStateCommandRepository : ModelCommandRepository<CreditAccountStateModel, CreditAccountStateDto>, ICreditAccountStateCommandRepository
    {
        public CreditAccountStateCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(CreditAccountStateModel model, CreditAccountStateDto modelDto)
        {
            model.InterestCounted.Currency = GetCurrencyModel(modelDto.InterestCounted.Currency?.Id);
            model.FinesForOverdue.Currency = GetCurrencyModel(modelDto.FinesForOverdue.Currency?.Id);
            model.RemainDebt.Currency = GetCurrencyModel(modelDto.RemainDebt.Currency?.Id);
            model.MainDebtRemain.Currency = GetCurrencyModel(modelDto.MainDebtRemain.Currency?.Id);
            model.TotalInterestSumNotPaid.Currency = GetCurrencyModel(modelDto.TotalInterestSumNotPaid.Currency?.Id);
            model.CreditAccount = GetCreditAccountModel(modelDto.CreditAccount?.Id);
        }
    }
}