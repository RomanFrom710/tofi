using BLL.Services.Auth;
using BLL.Services.Employee.ViewModels;
using BLL.Services.User;
using DAL.Repositories.Employee;
using TOFI.TransferObjects.Employee.DataObjects;

namespace BLL.Services.Employee
{
    public class EmployeeService : UserService<EmployeeDto, EmployeeViewModel>, IEmployeeService
    {
        private readonly IEmployeeQueryRepository _queryRepository;
        private readonly IEmployeeCommandRepository _commandRepository;


        public EmployeeService(IEmployeeQueryRepository queryRepository,
            IEmployeeCommandRepository commandRepository, IAuthService authService)
            : base(queryRepository, commandRepository, authService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}