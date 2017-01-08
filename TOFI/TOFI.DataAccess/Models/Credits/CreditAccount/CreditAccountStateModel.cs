using AutoMapper;
using DAL.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Credits.CreditAccount
{
    [Table("CreditAccountStates")]
    public class CreditAccountStateModel: Model
    {
        public int Month { get; set; }

        #region Virtual Properties

        public virtual PriceModel TotalDebt { get; set; }

        public virtual PriceModel InterestCounted { get; set; }

        public virtual PriceModel FinesForOverdue { get; set; }

        public virtual PriceModel RemainDebt { get; set; }

        [IgnoreMap]
        public virtual CreditAccountModel CreditAccount { get; set; }

        #endregion
    }
}
