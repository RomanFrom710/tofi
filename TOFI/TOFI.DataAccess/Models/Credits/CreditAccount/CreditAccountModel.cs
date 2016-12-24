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
    public class CreditAccountModel : Model
    {
        public string CreditAgreementNumber { get; set; }

        public double Percent { get; set; }

        #region Virtual Properties

        public virtual PriceModel TotalDebt { get; set; }

        public virtual PriceModel FinesForOverdue { get; set; }

        public virtual PriceModel RemainDebt { get; set; }

        public virtual UserModel User { get; set; }

        public virtual BankCreditModel BankCredit { get; set; }

        #endregion


    }
}
