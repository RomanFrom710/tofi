namespace DAL.Models.Common
{
    public class PriceModel: Model
    {
        public decimal Value { get; set; }

        public virtual CurrencyModel Currency { get; set; }
    }
}