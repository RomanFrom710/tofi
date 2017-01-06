using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using DAL.Models.Credits.BankCredits.CreditConditions;
using DAL.Models.Credits.BankCredits.CreditRequirements;
using DAL.Models.Credits.CreditAccount;
using DAL.Models.Credits.CreditRequest;

namespace DAL.Models.Credits.BankCredits.CreditTypes
{
    [Table("CreditTypes")]
    public class CreditTypeModel : Model
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double InterestRate { get; set; }

        #region Virtual Properties

        public virtual ICollection<CreditConditionModel> CreditConditions { get; set; }

        public virtual ICollection<CreditRequirementModel> CreditRequirements { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditAccountModel> CreditAccounts { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditRequestModel> CreditRequests { get; set; }

        #endregion
    }
}