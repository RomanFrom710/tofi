using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Credits.BankCredits.CreditTypes;
using System.Collections.Generic;
using AutoMapper;
using DAL.Models.Credits.CreditPayment;
using System;
using DAL.Models.Common;
using DAL.Models.Client;
using DAL.Models.Credits.CreditRequest;

namespace DAL.Models.Credits.CreditAccount
{
    [Table("CreditAccounts")]
    public class CreditAccountModel : Model
    {
        public string CreditAgreementNumber { get; set; }

        public string Description { get; set; }

        public DateTime AgreementDate { get; set; }

        public int TotalMonthDuration { get; set; }


        #region Virtual Properties

        [IgnoreMap]
        public virtual CurrencyModel Currency { get; set; }

        [IgnoreMap]
        public virtual ClientModel Client { get; set; }

        [IgnoreMap]
        public virtual CreditTypeModel CreditType { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditPaymentModel> Payments { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditAccountStateModel> CreditAccountStates { get; set; }

        [IgnoreMap]
        public virtual CreditRequestModel CreditRequest { get; set; }

        #endregion
    }
}