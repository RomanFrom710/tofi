using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Common;
using DAL.Models.User;
using DAL.Models.Credits.BankCredits.CreditTypes;

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

        public virtual UserModel User { get; set; }

        public virtual CreditTypeModel CreditType { get; set; }

        #endregion
    }
}