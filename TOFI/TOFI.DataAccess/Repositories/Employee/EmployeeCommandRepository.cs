using DAL.Contexts;
using DAL.Models.Employee;
using DAL.Repositories.User;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Employee
{
    public class EmployeeCommandRepository : UserCommandRepository<EmployeeModel, EmployeeDto>, IEmployeeCommandRepository
    {
        public EmployeeCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}