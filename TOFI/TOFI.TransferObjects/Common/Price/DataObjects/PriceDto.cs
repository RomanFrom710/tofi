using TOFI.TransferObjects.Common.Currency.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Common.Price.DataObjects
{
    public class PriceDto : ModelDto
    {
        public decimal Value { get; set; }

        public CurrencyDto Currency { get; set; }
    }
}