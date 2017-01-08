using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Credits.CreditRequest.DataObjects
{
    public class CreditRequestDto: ModelDto
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

        public virtual PriceDto CreditSum { get; set; }

        public string CreditPurpose { get; set; }

        public bool? IsOpen { get; set; }

        #endregion

        #region Virtual Properties 

        public ClientDto Client { get; set; }

        public EmployeeDto OperatorApproved { get; set; }

        public EmployeeDto SecurityApproved { get; set; }

        public EmployeeDto CreditCommitteeApproved { get; set; }

        public EmployeeDto CreditDepartmentApproved { get; set; }

        public CreditTypeDto CreditType { get; set; }

        public EmployeeDto RequestOpener { get; set; }

        #endregion
    }
}