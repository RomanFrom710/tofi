using DAL.Models.Common;
using DAL.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Credits.BankCredits;

namespace DAL.Models.Credits
{
    [Table("CreditAccounts")]
    public class CreditAccountModel : Model, ICreditAccountModel
    {
        public string CreditAgreementNumber { get; set; }

        public virtual PriceModel TotalDebt { get; set; }

        public virtual PriceModel FinesForOverdue { get; set; }

        public double Persent { get; set; }

        public virtual PriceModel RemainDebt { get; set; }

        public virtual IUserModel User { get; set; }

        public virtual IBankCreditModel BankCredit { get; set; }
    }
}
