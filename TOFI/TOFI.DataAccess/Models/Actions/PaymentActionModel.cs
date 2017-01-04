using DAL.Models.Credits.CreditPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Actions
{
    [Table("PaymentActions")]
    public class PaymentActionModel: ActionModel
    {

        #region Virtual Properties

        public virtual CreditPaymentModel CreditPayment { get; set; }

        #endregion
    }
}
