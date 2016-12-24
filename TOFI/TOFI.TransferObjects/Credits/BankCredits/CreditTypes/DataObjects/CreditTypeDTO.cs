using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects
{
    public class CreditTypeDTO: ModelDto
    {
        public List<CreditConditionDTO> CreditConditions { get; set; }

        public List<CreditRequirementDTO> CreditRequirement { get; set; }

        public List<BankCreditDTO> BankCredits { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }
    }
}
