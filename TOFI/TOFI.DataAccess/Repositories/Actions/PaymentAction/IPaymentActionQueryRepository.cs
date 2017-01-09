using DAL.Repositories.Model;
using TOFI.TransferObjects.Actions.PaymentAction.DataObjects;

namespace DAL.Repositories.Actions.PaymentAction
{
    public interface IPaymentActionQueryRepository : IModelQueryRepository<PaymentActionDto>
    {
    }
}