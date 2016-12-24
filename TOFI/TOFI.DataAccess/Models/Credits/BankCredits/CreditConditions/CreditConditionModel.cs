using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Credits.BankCredits.CreditType;

namespace DAL.Models.Credits.BankCredits.CreditCondition
{
    [Table("CreditConditions")]
    public class CreditConditionModel : Model
    {
       

        public int MonthDurationFrom { get; set; }

        public int MonthDurationTo { get; set; }

        #region Virtual Properties

        public virtual CreditTypeModel CreditType { get; set; }

        public virtual PriceModel MaxCreditSum { get; set; }

        public virtual PriceModel MinCreditSum { get; set; }

        #endregion
    }
}
