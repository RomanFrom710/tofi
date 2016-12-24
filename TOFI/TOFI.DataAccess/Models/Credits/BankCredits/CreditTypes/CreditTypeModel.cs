using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Credits.BankCredits.BankCredit;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;

namespace DAL.Models.Credits.BankCredits.CreditTypes
{
    [Table("CreditTypes")]
    public class CreditTypeModel : Model
    {
        public string Description { get; set; }

        public double InterestRate { get; set; }

        #region Virtual Properties

        public virtual ICollection<CreditConditionModel> CreditConditions { get; set; }

        public virtual ICollection<CreditRequirementModel> CreditRequirements { get; set; }

        public virtual ICollection<BankCreditModel> BankCredits { get; set; }

        #endregion
    }
}