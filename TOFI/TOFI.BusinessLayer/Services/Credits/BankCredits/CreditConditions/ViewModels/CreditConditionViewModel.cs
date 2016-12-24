using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.BankCredits.CreditConditions.ViewModels
{
    public class CreditConditionViewModel : ModelViewModel
    {
        public PriceViewModel MaxCreditSum { get; set; }

        public PriceViewModel MinCreditSum { get; set; }

        public int MonthDurationFrom { get; set; }

        public int MonthDurationTo { get; set; }
    }
}