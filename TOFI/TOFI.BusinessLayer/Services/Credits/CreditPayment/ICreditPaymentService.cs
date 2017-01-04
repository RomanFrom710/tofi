using BLL.Services.Credits.CreditPayment.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace BLL.Services.Credits.CreditPayment
{
    public interface ICreditPaymentService : IModelService<CreditPaymentDto, CreditPaymentViewModel>
    {
    }
}