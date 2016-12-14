using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOFI.TransferObjects.Common.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.BankCredit.DataObjects
{
    public class BankCreditDTO: ModelDto
    {
        public string Description { get; set; }

        public double InterestRate { get; set; }

        public int MonthDuration { get; set; }

        public PriceDTO Sum { get; set; }
    }
}
