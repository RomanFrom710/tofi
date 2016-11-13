using DAL.Contexts;
using DAL.Models.Employee;
using DAL.Repositories.User;

namespace DAL.Repositories.Employee
{
    public class EmployeeCommandRepository : UserCommandRepository<EmployeeModel>, IEmployeeCommandRepository
    {
        public EmployeeCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}