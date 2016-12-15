using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Common.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects
{
    public class CreditConditionDTO: ModelDto
    {
        public PriceDTO MaxCreditSum { get; set; }

        public PriceDTO MinCreditSum { get; set; }

        public int MonthDurationFrom { get; set; }

        public int MonthDurationTo { get; set; }
    }
}
