using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Credits.BankCredits.CreditCondition;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Credits.BankCredits.CreditType
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
