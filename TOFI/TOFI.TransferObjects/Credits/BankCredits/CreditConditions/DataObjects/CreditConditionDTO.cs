using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects
{
    public class CreditConditionDto : ModelDto
    {
        public PriceDto MaxCreditSum { get; set; }

        public PriceDto MinCreditSum { get; set; }

        public int MonthDurationFrom { get; set; }

        public int MonthDurationTo { get; set; }
    }
}