using DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits.BankCredits
{
    public interface IBankCreditModel: IModel
    {
        int MonthDuration { get; set; }

        double InterestRate { get; set; }

        string Description { get; set; }

        PriceModel Sum { get; set; }
    }
}
