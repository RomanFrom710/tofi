using DAL.Models.Credits.CreditPayment;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Actions
{
    [Table("PaymentActions")]
    public class PaymentActionModel : ActionModel
    {
        #region Virtual Properties

        public virtual CreditPaymentModel CreditPayment { get; set; }

        #endregion
    }
}