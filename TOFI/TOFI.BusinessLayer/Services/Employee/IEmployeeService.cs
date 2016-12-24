using BLL.Services.Employee.ViewModels;
using BLL.Services.Model;
using BLL.Services.User;
using TOFI.TransferObjects.Employee.DataObjects;

namespace BLL.Services.Employee
{
    public interface IEmployeeService : IModelService<EmployeeDto, EmployeeViewModel>
    {
    }
}