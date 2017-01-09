using DAL.Models.Credits.CreditPayment;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace DAL.Models.Actions
{
    [Table("PaymentActions")]
    public class PaymentActionModel : ActionModel
    {
        #region Virtual Properties

        [IgnoreMap]
        public virtual CreditPaymentModel CreditPayment { get; set; }

        #endregion
    }
}