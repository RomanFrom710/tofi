using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;
using TOFI.TransferObjects.Employee.DataObjects;
using DAL.Models.Credits.CreditRequest;
using System.Collections.Generic;
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

        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedSecurity { get; set; }

        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedCommittee { get; set; }

        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedDepartment { get; set; }

        public virtual ICollection<CreditRequestModel> CreditRequestsApprovedCashier { get; set; }

        public virtual ICollection<CreditPaymentModel> CreditPayments { get; set; }

        public virtual ICollection<ActionModel> Actions { get; set; }

        #endregion
    }
}