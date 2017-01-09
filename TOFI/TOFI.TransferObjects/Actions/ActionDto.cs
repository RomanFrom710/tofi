using System;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Actions
{
    public abstract class ActionDto : ModelDto
    {
        public string Signature { get; set; }

        public DateTime Timestamp { get; set; }

        public string ActionType { get; set; }

        public virtual EmployeeDto Employee { get; set; }
    }
}