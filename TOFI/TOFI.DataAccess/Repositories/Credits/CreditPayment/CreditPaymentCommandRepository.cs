using DAL.Contexts;
using DAL.Models.Credits.CreditPayment;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace DAL.Repositories.Credits.CreditPayment
{
    public class CreditPaymentCommandRepository : ModelCommandRepository<CreditPaymentModel, CreditPaymentDto>, ICreditPaymentCommandRepository
    {
        public CreditPaymentCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(CreditPaymentModel model, CreditPaymentDto modelDto)
        {
            model.CreditAccount = GetCreditAccountModel(modelDto.CreditAccount?.Id);
            model.PaymentSum.Currency = GetCurrencyModel(modelDto.PaymentSum.Currency?.Id);
            model.Employee = GetEmployeeModel(modelDto.Employee?.Id);
        }
    }
}