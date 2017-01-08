using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.User.DataObjects;

namespace TOFI.TransferObjects.Credits.CreditAccount.DataObjects
{
    public class CreditAccountDto : ModelDto
    {
        public string CreditAgreementNumber { get; set; }

        public PriceDto TotalDebt { get; set; }

        public PriceDto FinesForOverdue { get; set; }

        public string Description { get; set; }

        public PriceDto RemainDebt { get; set; }

        public UserDto User { get; set; }

        public CreditTypeDto CreditType { get; set; }
    }
}