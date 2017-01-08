using System.Collections.Generic;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects
{
    public class CreditTypeDto : ModelDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }

        public bool IsArchived { get; set; }

        public decimal FineInterest { get; set; }

        public List<CreditConditionDto> CreditConditions { get; set; }

        public List<CreditRequirementDto> CreditRequirements { get; set; }
    }
}