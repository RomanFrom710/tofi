using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.CreditAccountState.ViewModels
{
    public class CreditAccountStateViewModel: ModelViewModel
    {
        public int Month { get; set; }
        
        public PriceViewModel InterestCounted { get; set; }

        public PriceViewModel FinesForOverdue { get; set; }

        public PriceViewModel RemainDebt { get; set; }

        public PriceViewModel TotalInterestSumNotPaid { get; set; }

        public CreditAccountViewModel CreditAccount { get; set; }
    }
}
