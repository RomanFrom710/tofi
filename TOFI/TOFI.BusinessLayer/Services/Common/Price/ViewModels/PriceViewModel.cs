using System.ComponentModel.DataAnnotations;
using BLL.Attributes;
using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Common.Price.ViewModels
{
    public class PriceViewModel : ModelViewModel
    {
        [CustomRequired]
        [Range(1, int.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
        public decimal Value { get; set; }

        public CurrencyViewModel Currency { get; set; }
    }
}