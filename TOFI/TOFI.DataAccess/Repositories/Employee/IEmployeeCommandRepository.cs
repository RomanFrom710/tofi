using DAL.Repositories.User;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Employee
{
    public interface IEmployeeCommandRepository : IUserCommandRepository<EmployeeDto>
    {
    }
}