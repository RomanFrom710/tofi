using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditCondition;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits.BankCredits
{
    public interface IBankCreditModel: IModel
    {
        ICreditConditionModel CreditConditions { get; set; }

        ICreditRequirementModel CreditRequirement { get; set; }
        
        double InterestRate { get; set; }

        ICreditTypeModel CreditType { get; set; }
    }
}
