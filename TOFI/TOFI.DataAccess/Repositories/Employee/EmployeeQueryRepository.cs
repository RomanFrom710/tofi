using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Employee.Queries;

namespace DAL.Repositories.Employee
{
    public class EmployeeQueryRepository : ModelQueryRepository<EmployeeModel, EmployeeDto>, IEmployeeQueryRepository
    {
        public EmployeeQueryRepository(TofiContext context) : base(context)
        {
        }


        public EmployeeDto Handle(EmployeeQuery query)
        {
            EmployeeModel model = null;
            if (query.Id.HasValue)
            {
                model = ModelsDao.Find(query.Id.Value);
            }
            if (query.UserId.HasValue)
            {
                model = ModelsDao.FirstOrDefault(e => e.User.Id == query.UserId);
            }
            return model == null ? null : Mapper.Map<EmployeeDto>(model);
        }

        public async Task<EmployeeDto> HandleAsync(EmployeeQuery query)
        {
            EmployeeModel model = null;
            if (query.Id.HasValue)
            {
                model = await ModelsDao.FindAsync(query.Id.Value);
            }
            if (query.UserId.HasValue)
            {
                model = await ModelsDao.FirstOrDefaultAsync(e => e.User.Id == query.UserId);
            }
            return model == null ? null : Mapper.Map<EmployeeDto>(model);
        }
    }
}