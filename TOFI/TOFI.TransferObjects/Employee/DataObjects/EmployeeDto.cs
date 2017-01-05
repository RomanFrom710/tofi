using System;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Employee.DataObjects
{
    [Flags]
    public enum EmployeeRights
    {
        None = 0,
        Cashier = 1,
        Operator = 2,
        SecurityOfficer = 4,
        CreditCommitteeMember = 8,
        CreditDepartmentChief = 16,
        Handyman = 31,
        Admin = 32,
        Superuser = int.MaxValue,
    }


    public class EmployeeDto : ModelDto
    {
        public EmployeeRights Rights { get; set; }
    }
}