using BLL.Services.Employee.ViewModels;
using BLL.Services.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Employee.DataObjects;

namespace BLL.Services.Employee
{
    public class EmployeeService : UserService<EmployeeDto, EmployeeViewModel>, IEmployeeService
    {
        public EmployeeService(IModelQueryRepository<EmployeeDto> queryRepository,
            IModelCommandRepository<EmployeeDto> commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}