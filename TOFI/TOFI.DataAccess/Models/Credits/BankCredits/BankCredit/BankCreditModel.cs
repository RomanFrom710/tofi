using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditCondition;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.BankCredits.CreditType;

namespace DAL.Models.Credits.BankCredits
{
    [Table("BankCredits")]
    public class BankCreditModel : Model
    {
        
        public string Description { get; set; }

        public double InterestRate { get; set; }

        #region Virtual Properties
        
        public virtual CreditTypeModel CreditType { get; set; }

        public virtual CreditAccountModel CreditAccount { get; set; }

        #endregion

    }
}
