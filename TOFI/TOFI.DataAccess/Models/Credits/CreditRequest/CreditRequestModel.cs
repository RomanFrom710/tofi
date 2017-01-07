using DAL.Models.Client;
using DAL.Models.Common;
using DAL.Models.Credits.BankCredits.CreditTypes;
using DAL.Models.Employee;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace DAL.Models.Credits.CreditRequest
{
    [Table("CreditRequests")]
    public class CreditRequestModel : Model
    {
        #region Approved

        public bool? IsOperatorApproved { get; set; }

        public bool? IsSecurityApproved { get; set; }

        public bool? IsCreditCommitteeApproved { get; set; }

        public bool? IsCreditDepartmentApproved { get; set; }

        #endregion

        #region Comments

        public string OperatorComments { get; set; }

        public string SecurityComments { get; set; }

        public string CreditCommitteeComments { get; set; }

        public string CreditDepartmentComments { get; set; }

        #endregion

        #region Condition

        public int MonthDuration { get; set; }

        public virtual PriceModel CreditSum { get; set; }

        public string CreditPurpose { get; set; }

        #endregion

        #region Virtual Properties 

        [IgnoreMap]
        public virtual ClientModel Client { get; set; }

        [IgnoreMap]
        public virtual EmployeeModel OperatorApproved { get; set; }

        [IgnoreMap]
        public virtual EmployeeModel SecurityApproved { get; set; }

        [IgnoreMap]
        public virtual EmployeeModel CreditCommitteeApproved { get; set; }

        [IgnoreMap]
        public virtual EmployeeModel CreditDepartmentApproved { get; set; }

        [IgnoreMap]
        public virtual CreditTypeModel CreditType { get; set; }

        #endregion
    }
}