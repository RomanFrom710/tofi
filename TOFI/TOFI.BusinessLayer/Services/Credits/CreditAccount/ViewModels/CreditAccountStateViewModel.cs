using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Credits.CreditAccount.ViewModels
{
    public class CreditAccountStateViewModel: ModelViewModel
    {
        public int Month { get; set; }

        public PriceViewModel TotalDebt { get; set; }

        public PriceViewModel InterestCounted { get; set; }

        public PriceViewModel FinesForOverdue { get; set; }

        public PriceViewModel RemainDebt { get; set; }

        public PriceViewModel TotalInterestSumNotPaid { get; set; }

        public CreditAccountViewModel CreditAccount { get; set; }
    }
}
