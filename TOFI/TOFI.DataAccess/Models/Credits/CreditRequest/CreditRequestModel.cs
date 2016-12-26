using DAL.Models.Client;
using DAL.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits.CreditRequest
{
    [Table("CreditRequests")]
    public class CreditRequestModel: Model
    {
        #region Approved

        public bool IsSecurityApproved { get; set; }

        public bool IsCreditCommitteeApproved { get; set; }

        public bool IsCreditDepartmentApproved { get; set; }

        public bool IsCashierApproved { get; set; }

        #endregion

        #region Comments

        public string SecurityComments { get; set; }

        public string CreditCommitteeComments { get; set; }

        public string CreditDepartmentComments { get; set; }

        public string CashierComments { get; set; }

        #endregion

        #region Virtual Properties 

        public virtual ClientModel Client { get; set; }

        public virtual EmployeeModel SecurityApproved { get; set; }

        public virtual EmployeeModel CreditCommitteeApproved { get; set; }

        public virtual EmployeeModel CreditDepartmentApproved { get; set; }

        public virtual EmployeeModel CashierApproved { get; set; }

        #endregion
    }
}
