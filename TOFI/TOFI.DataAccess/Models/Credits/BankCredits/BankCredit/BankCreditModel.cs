using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditCondition;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditType;

namespace DAL.Models.Credits.BankCredits
{
    [Table("BankCredits")]
    public class BankCreditModel : Model, IBankCreditModel
    {
        public virtual ICreditConditionModel CreditConditions { get; set; }

        public virtual ICreditRequirementModel CreditRequirement { get; set; }

        public virtual ICreditTypeModel CreditType { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }
        
    }
}
