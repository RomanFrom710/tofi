using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Models.Credits.CreditAccount;

namespace DAL.Models.Credits.BankCredits.BankCredit
{
    [Table("BankCredits")]
    public class BankCreditModel : Model
    {
        public string Description { get; set; }

        public double InterestRate { get; set; }

        #region Virtual Properties
        
        public virtual CreditTypeModel CreditType { get; set; }

        public virtual CreditAccountModel CreditAccount { get; set; }

        #endregion
    }
}