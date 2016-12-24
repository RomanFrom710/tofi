using DAL.Repositories.Model;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Employee
{
    public interface IEmployeeQueryRepository : IModelQueryRepository<EmployeeDto>
    {
    }
}