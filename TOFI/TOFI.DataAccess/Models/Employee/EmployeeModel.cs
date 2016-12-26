using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;
using TOFI.TransferObjects.Employee.DataObjects;
using DAL.Models.Credits.CreditRequest;
using System.Collections.Generic;

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

        #endregion
    }
}