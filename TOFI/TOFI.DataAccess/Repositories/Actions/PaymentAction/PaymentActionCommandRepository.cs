using DAL.Contexts;
using DAL.Models.Actions;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Actions.PaymentAction.DataObjects;

namespace DAL.Repositories.Actions.PaymentAction
{
    public class PaymentActionCommandRepository : ModelCommandRepository<PaymentActionModel, PaymentActionDto>, IPaymentActionCommandRepository
    {
        public PaymentActionCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(PaymentActionModel model, PaymentActionDto modelDto)
        {
            model.Employee = GetEmployeeModel(modelDto.Employee?.Id);
            model.CreditPayment = GetCreditPaymentModel(modelDto.CreditPayment?.Id);
        }
    }
}