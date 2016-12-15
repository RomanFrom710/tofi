using DAL.Models.Credits.BankCredits.CreditCondition;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits.BankCredits.CreditType
{
    public interface ICreditTypeModel: IModel
    {
        IEnumerable<ICreditConditionModel> CreditConditions { get; set; }

        IEnumerable<ICreditRequirementModel> CreditRequirement { get; set; }

        double InterestRate { get; set; }

        string Description { get; set; }
    }
}
