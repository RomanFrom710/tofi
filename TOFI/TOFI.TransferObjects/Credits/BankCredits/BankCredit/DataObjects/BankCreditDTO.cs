using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects
{
    public class BankCreditDto : ModelDto
    {
        public CreditTypeDto CreditType { get; set; }

        public CreditAccountDto CreditAccount { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }
    }
}