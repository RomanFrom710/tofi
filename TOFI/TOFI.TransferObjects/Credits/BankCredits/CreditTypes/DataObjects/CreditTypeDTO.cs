using System.Collections.Generic;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects
{
    public class CreditTypeDto : ModelDto
    {
        public List<CreditConditionDto> CreditConditions { get; set; }

        public List<CreditRequirementDto> CreditRequirement { get; set; }

        public List<BankCreditDto> BankCredits { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }
    }
}