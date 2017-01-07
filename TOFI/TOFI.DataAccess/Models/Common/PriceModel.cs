using AutoMapper;

namespace DAL.Models.Common
{
    public class PriceModel: Model
    {
        public decimal Value { get; set; }

        [IgnoreMap]
        public virtual CurrencyModel Currency { get; set; }
    }
}