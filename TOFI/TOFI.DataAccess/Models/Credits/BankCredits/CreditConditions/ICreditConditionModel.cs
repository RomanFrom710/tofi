using DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits.BankCredits.CreditCondition
{
    public interface ICreditConditionModel: IModel
    {
        int MonthDurationFrom { get; set; }

        int MonthDurationTo { get; set; }

        PriceModel MinCreditSum { get; set; }

        PriceModel MaxCreditSum { get; set; }
    }
}
