using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects
{
    public class CreditRequirementDto : ModelDto
    {
        public string Description { get; set; }

        public string ExpectedValue { get; set; }

        public CreditTypeDto CreditType { get; set; }
    }
}