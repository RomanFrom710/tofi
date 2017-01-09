using DAL.Models.Employee;
using System;
using AutoMapper;

namespace DAL.Models.Actions
{
    public abstract class ActionModel : Model
    {
        public string Signature { get; set; }

        public DateTime Timestamp { get; set; }

        public string ActionType { get; set; }

        #region Virtual Properties

        [IgnoreMap]
        public virtual EmployeeModel Employee { get; set; }

        #endregion
    }
}