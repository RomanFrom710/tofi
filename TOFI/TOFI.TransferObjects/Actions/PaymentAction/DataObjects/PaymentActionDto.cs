using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace TOFI.TransferObjects.Actions.PaymentAction.DataObjects
{
    public class PaymentActionDto : ActionDto
    {
        public CreditPaymentDto CreditPayment { get; set; }
    }
}