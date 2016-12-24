using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Common.DataObjects
{
    public class PriceDto : ModelDto
    {
        public decimal Value { get; set; }

        public CurrencyDto Currency { get; set; }
    }
}