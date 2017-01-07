using DAL.Models.Employee;
using System;

namespace DAL.Models.Actions
{
    public abstract class ActionModel : Model
    {
        public string Signature { get; set; }

        public DateTime Timestamp { get; set; }

        public string ActionType { get; set; }

        #region Virtual Properties

        public virtual EmployeeModel Employee { get; set; }

        #endregion
    }
}