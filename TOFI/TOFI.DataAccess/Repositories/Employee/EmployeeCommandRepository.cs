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
            model.User = GetUserModel(modelDto.User?.Id);
            if (modelDto.User != null)
            {
                model.User.FirstName = modelDto.User.FirstName;
                model.User.MiddleName = modelDto.User.MiddleName;
                model.User.LastName = modelDto.User.LastName;
            }
        }
    }
}