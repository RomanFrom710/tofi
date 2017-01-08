using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.CreditAccount.DataObjects
{
    public class CreditAccountStateDto: ModelDto
    {
        public int Month { get; set; }

        public PriceDto TotalDebt { get; set; }

        public PriceDto InterestCounted { get; set; }

        public PriceDto FinesForOverdue { get; set; }

        public PriceDto RemainDebt { get; set; }

        public PriceDto TotalInterestSumNotPaid { get; set; }

        public CreditAccountDto CreditAccount { get; set; }
    }
}
