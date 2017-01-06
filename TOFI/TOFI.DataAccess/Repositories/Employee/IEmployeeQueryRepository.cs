using DAL.Repositories.Model;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Employee.Queries;

namespace DAL.Repositories.Employee
{
    public interface IEmployeeQueryRepository : IModelQueryRepository<EmployeeDto>,
        IQueryRepository<EmployeeQuery, EmployeeDto>
    {
    }
}