using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;
using TOFI.TransferObjects.Employee.DataObjects;
using DAL.Models.Credits.CreditRequest;
using System.Collections.Generic;
using AutoMapper;
using DAL.Models.Credits.CreditPayment;
using DAL.Models.Actions;

namespace DAL.Models.Employee
{
    [Table("Employees")]
    public class EmployeeModel : Model
    {
        public EmployeeRights Rights { get; set; }

        #region Virtual Properties

        public virtual UserModel User { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedSecurity { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedCommittee { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedDepartment { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedCashier { get; set; }

        [IgnoreMap]
        public virtual ICollection<CreditPaymentModel> CreditPayments { get; set; }

        [IgnoreMap]
        public virtual ICollection<RequestActionModel> RequestActions { get; set; }

        [IgnoreMap]
        public virtual ICollection<PaymentActionModel> PaymentActions { get; set; }

        #endregion
    }
}