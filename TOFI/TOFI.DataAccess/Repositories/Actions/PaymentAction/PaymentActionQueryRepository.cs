using DAL.Contexts;
using DAL.Models.Actions;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Actions.PaymentAction.DataObjects;

namespace DAL.Repositories.Actions.PaymentAction
{
    public class PaymentActionQueryRepository : ModelQueryRepository<PaymentActionModel, PaymentActionDto>, IPaymentActionQueryRepository
    {
        public PaymentActionQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}