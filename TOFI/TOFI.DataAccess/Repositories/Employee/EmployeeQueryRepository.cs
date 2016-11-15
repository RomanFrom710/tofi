using DAL.Contexts;
using DAL.Models.Employee;
using DAL.Repositories.User;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Employee
{
    public class EmployeeQueryRepository : UserQueryRepository<EmployeeModel, EmployeeDto>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}