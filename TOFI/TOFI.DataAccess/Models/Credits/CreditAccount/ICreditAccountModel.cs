using DAL.Models.Common;
using DAL.Models.Credits.BankCredits;
using DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits
{
    public interface ICreditAccountModel: IModel
    {
        string CreditAgreementNumber { get; }

        PriceModel TotalDebt { get; set; }

        PriceModel RemainDebt { get; set; }
        
        PriceModel FinesForOverdue { get; set; }

        IUserModel User { get; set; }

        IBankCreditModel BankCredit { get; set; }
    }
}
