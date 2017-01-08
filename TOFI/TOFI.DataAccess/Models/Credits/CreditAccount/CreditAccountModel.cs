using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;
using DAL.Models.Credits.BankCredits.CreditTypes;
using System.Collections.Generic;
using AutoMapper;
using DAL.Models.Credits.CreditPayment;
using System;

namespace DAL.Models.Credits.CreditAccount
{
    [Table("CreditAccounts")]
    public class CreditAccountModel : Model
    {
        public string CreditAgreementNumber { get; set; }

        public string Description { get; set; }

        public DateTime AgreementDate { get; set; }

        #region Virtual Properties
        
        [IgnoreMap]
        public virtual UserModel User { get; set; }

        [IgnoreMap]
        public virtual CreditTypeModel CreditType { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditPaymentModel> Payments { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditAccountStateModel> CreditAccountStates { get; set; }

        #endregion
    }
}