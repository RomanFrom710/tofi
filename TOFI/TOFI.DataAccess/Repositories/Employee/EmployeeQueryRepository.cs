using DAL.Contexts;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Employee
{
    public class EmployeeQueryRepository : ModelQueryRepository<EmployeeModel, EmployeeDto>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}