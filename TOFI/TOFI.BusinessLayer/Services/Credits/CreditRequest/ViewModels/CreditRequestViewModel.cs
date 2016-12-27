using BLL.Services.Client.ViewModels;
using BLL.Services.Employee.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Credits.CreditRequest.ViewModels
{
    public class CreditRequestViewModel : ModelViewModel
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

        public ClientViewModel Client { get; set; }

        public EmployeeViewModel SecurityApproved { get; set; }

        public EmployeeViewModel CreditCommitteeApproved { get; set; }

        public EmployeeViewModel CreditDepartmentApproved { get; set; }

        public EmployeeViewModel CashierApproved { get; set; }

        #endregion
    }
}