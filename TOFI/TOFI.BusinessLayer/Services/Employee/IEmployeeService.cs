using BLL.Services.Employee.ViewModels;
using BLL.Services.User;
using TOFI.TransferObjects.Employee.DataObjects;

namespace BLL.Services.Employee
{
    public interface IEmployeeService : IUserService<EmployeeDto, EmployeeViewModel>
    {
    }
}