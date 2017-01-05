using DAL.Models.Common;
using System;
using DAL.Models.Credits.CreditAccount;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Employee;

namespace DAL.Models.Credits.CreditPayment
{
    [Table("CreditPayments")]
    public class CreditPaymentModel: Model
    {
        public DateTime Timestamp { get; set; }

        #region Virtual Properties

        public virtual PriceModel PaymentSum { get; set; }

        public virtual CreditAccountModel CreditAccount { get; set; }

        public virtual EmployeeModel Employee { get; set; }

        #endregion
    }
}
