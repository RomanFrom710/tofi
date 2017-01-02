using DAL.Models.Common;
using DAL.Models.User;
using System;
using DAL.Models.Credits.CreditAccount;

namespace DAL.Models.Credits.CreditPayment
{
    public class CreditPaymentModel: Model
    {
        public DateTime Timestamp { get; set; }

        #region Virtual Properties

        public virtual PriceModel PaymentSum { get; set; }

        public virtual CreditAccountModel CreditAccount { get; set; }

        #endregion
    }
}
