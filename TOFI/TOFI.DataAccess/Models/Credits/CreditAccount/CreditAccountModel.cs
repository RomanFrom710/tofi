using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.BankCredit;
using DAL.Models.User;

namespace DAL.Models.Credits.CreditAccount
{
    [Table("CreditAccounts")]
    public class CreditAccountModel : Model
    {
        public string CreditAgreementNumber { get; set; }

        public double Percent { get; set; }

        #region Virtual Properties

        public virtual PriceModel TotalDebt { get; set; }

        public virtual PriceModel FinesForOverdue { get; set; }

        public virtual PriceModel RemainDebt { get; set; }

        public virtual UserModel User { get; set; }

        public virtual BankCreditModel BankCredit { get; set; }

        #endregion
    }
}