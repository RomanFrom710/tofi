using AutoMapper;
using DAL.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Credits.CreditAccount
{
    [Table("CreditAccountStates")]
    public class CreditAccountStateModel : Model
    {
        public int Month { get; set; }

        #region Virtual Properties

        // for latest month
        public virtual PriceModel InterestCounted { get; set; }

        // for latest month
        public virtual PriceModel FinesForOverdue { get; set; }

        // overall
        public virtual PriceModel RemainDebt { get; set; }

        // overall for all previous months
        public virtual PriceModel TotalInterestSumNotPaid { get; set; }

        [IgnoreMap]
        public virtual CreditAccountModel CreditAccount { get; set; }

        #endregion
    }
}