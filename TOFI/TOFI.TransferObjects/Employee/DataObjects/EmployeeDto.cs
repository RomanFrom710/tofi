using System;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Employee.DataObjects
{
    [Flags]
    public enum EmployeeRights
    {
        None = 0,
        Admin = int.MaxValue,
    }


    public class EmployeeDto : ModelDto
    {
        public EmployeeRights Rights { get; set; }
    }
}