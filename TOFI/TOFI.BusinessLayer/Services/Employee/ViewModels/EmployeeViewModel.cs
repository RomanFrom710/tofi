using BLL.Services.Model.ViewModels;
using TOFI.TransferObjects.Employee.DataObjects;

namespace BLL.Services.Employee.ViewModels
{
    public class EmployeeViewModel : ModelViewModel
    {
        public EmployeeRights Rights { get; set; }
    }
}