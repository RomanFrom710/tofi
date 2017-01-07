using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditTypes;

namespace DAL.Models.Credits.BankCredits.CreditConditions
{
    [Table("CreditConditions")]
    public class CreditConditionModel : Model
    {
        public int MonthDurationFrom { get; set; }

        public int MonthDurationTo { get; set; }

        #region Virtual Properties

        [IgnoreMap]
        public virtual CreditTypeModel CreditType { get; set; }

        public virtual PriceModel MaxCreditSum { get; set; }

        public virtual PriceModel MinCreditSum { get; set; }

        #endregion
    }
}