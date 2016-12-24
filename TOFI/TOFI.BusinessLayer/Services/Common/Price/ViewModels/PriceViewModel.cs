using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Common.Price.ViewModels
{
    public class PriceViewModel : ModelViewModel
    {
        public decimal Value { get; set; }

        public CurrencyViewModel Currency { get; set; }
    }
}