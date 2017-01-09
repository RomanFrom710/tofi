using TOFI.TransferObjects.Common.Price.DataObjects;

namespace TOFI.TransferObjects.Client.Queries
{
    public class SelectCreditTypesQuery : Query
    {
        public int MonthDuration { get; set; }

        public PriceDto CreditSum { get; set; }

        public string CreditPurpose { get; set; }
    }
}