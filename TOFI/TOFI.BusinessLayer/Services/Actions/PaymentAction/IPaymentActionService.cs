using BLL.Services.Actions.PaymentAction.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Actions.PaymentAction.DataObjects;

namespace BLL.Services.Actions.PaymentAction
{
    public interface IPaymentActionService : IModelService<PaymentActionDto, PaymentActionViewModel>
    {
    }
}