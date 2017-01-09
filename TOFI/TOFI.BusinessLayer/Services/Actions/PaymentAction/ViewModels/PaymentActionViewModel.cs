using BLL.Services.Credits.CreditPayment.ViewModels;

namespace BLL.Services.Actions.PaymentAction.ViewModels
{
    public class PaymentActionViewModel : ActionViewModel
    {
        public CreditPaymentViewModel CreditPayment { get; set; }
    }
}