using TOFI.TransferObjects.Common.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects
{
    public class CreditConditionDto : ModelDto
    {
        public PriceDto MaxCreditSum { get; set; }

        public PriceDto MinCreditSum { get; set; }

        public CreditTypeDto CreditType { get; set; }

        public int MonthDurationFrom { get; set; }

        public int MonthDurationTo { get; set; }
    }
}