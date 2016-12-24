using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects
{
    public class BankCreditDTO: ModelDto
    {
        public CreditTypeDTO CreditType { get; set; }

        public CreditAccountDTO CreditAccount { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }
    }
}
