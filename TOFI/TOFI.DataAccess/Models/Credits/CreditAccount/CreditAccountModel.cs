using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Common;
using DAL.Models.User;
using DAL.Models.Credits.BankCredits.CreditTypes;
using System.Collections.Generic;
using AutoMapper;
using DAL.Models.Credits.CreditPayment;

namespace DAL.Models.Credits.CreditAccount
{
    [Table("CreditAccounts")]
    public class CreditAccountModel : Model
    {
        public string CreditAgreementNumber { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }

        #region Virtual Properties

        public virtual PriceModel TotalDebt { get; set; }

        public virtual PriceModel FinesForOverdue { get; set; }

        public virtual PriceModel RemainDebt { get; set; }

        [IgnoreMap]
        public virtual UserModel User { get; set; }

        [IgnoreMap]
        public virtual CreditTypeModel CreditType { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditPaymentModel> Payments { get; set; }

        #endregion
    }
}