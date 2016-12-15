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
    public class CreditTypeModel : Model, ICreditTypeModel
    {
        public virtual IEnumerable<ICreditConditionModel> CreditConditions { get; set; }

        public virtual IEnumerable<ICreditRequirementModel> CreditRequirement { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }
    }
}
