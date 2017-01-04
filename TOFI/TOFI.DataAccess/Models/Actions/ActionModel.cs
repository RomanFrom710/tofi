using DAL.Models.Employee;
using DAL.Models.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Actions
{
    public abstract class ActionModel : Model
    {
        public string Signature { get; set; }

        public DateTime Timestamp { get; set; }

        #region Virtual Properties

        public virtual EmployeeModel Employee { get; set; }

        #endregion
    }
}
