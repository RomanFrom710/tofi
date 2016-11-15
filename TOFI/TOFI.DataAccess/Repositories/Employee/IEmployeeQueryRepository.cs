using DAL.Repositories.User;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Employee
{
    public interface IEmployeeQueryRepository : IUserQueryRepository<EmployeeDto>
    {
    }
}