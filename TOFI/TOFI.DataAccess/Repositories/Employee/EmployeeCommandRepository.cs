using DAL.Contexts;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Employee
{
    public class EmployeeCommandRepository : ModelCommandRepository<EmployeeModel, EmployeeDto>, IEmployeeCommandRepository
    {
        public EmployeeCommandRepository(TofiContext context) : base(context)
        {
        }


        protected override void RestoreFkModels(EmployeeModel model, EmployeeDto modelDto)
        {
            model.User = GetUserModel(model.User?.Id);
        }
    }
}