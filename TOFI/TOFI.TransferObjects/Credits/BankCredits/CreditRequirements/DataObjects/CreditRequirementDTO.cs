using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects
{
    public class CreditRequirementDTO: ModelDto
    {
        public string Description { get; set; }

        public string ExpectedValue { get; set; }

        public CreditTypeDTO CreditType { get; set; }
    }
}
