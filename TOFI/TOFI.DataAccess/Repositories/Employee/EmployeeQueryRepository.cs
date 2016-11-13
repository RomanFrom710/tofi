using DAL.Contexts;
using DAL.Models.Employee;
using DAL.Repositories.User;

namespace DAL.Repositories.Employee
{
    public class EmployeeQueryRepository : UserQueryRepository<EmployeeModel>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}