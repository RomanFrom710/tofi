using System;
using BLL.Services.Employee.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.Actions
{
    public abstract class ActionViewModel : ModelViewModel
    {
        public string Signature { get; set; }

        public DateTime Timestamp { get; set; }

        public string ActionType { get; set; }

        public virtual EmployeeViewModel Employee { get; set; }
    }
}