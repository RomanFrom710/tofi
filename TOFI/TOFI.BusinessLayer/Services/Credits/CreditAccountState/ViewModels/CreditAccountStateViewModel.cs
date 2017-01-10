using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.CreditAccountState.ViewModels
{
    public class CreditAccountStateViewModel: ModelViewModel
    {
        public int Month { get; set; }
        
        public PriceViewModel MainDebtRemain { get; set; }

        public PriceViewModel InterestCounted { get; set; }

        public PriceViewModel FinesForOverdue { get; set; }

        public PriceViewModel RemainDebt { get; set; }

        public PriceViewModel TotalInterestSumNotPaid { get; set; }

        public CreditAccountViewModel CreditAccount { get; set; }

        public PriceViewModel ToBePaidForMonth
        {
            get
            {
                var debtForMonth = RemainDebt.Value / (CreditAccount.TotalMonthDuration - Month);
                var interestForMonth = (decimal)CreditAccount.CreditType.InterestRate / 12 * RemainDebt.Value;
                return new PriceViewModel()
                {
                    Value = debtForMonth + interestForMonth,
                    Currency = CreditAccount.Currency
                };
            }
        }

    }
}
