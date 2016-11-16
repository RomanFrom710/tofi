using DAL.Contexts;
using DAL.Models.Admin;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Admin.DataObjects;

namespace DAL.Repositories.Admin
{
    public class AdminQueryRepository : ModelQueryRepository<AdminModel, AdminDto>, IAdminQueryRepository
    {
        public AdminQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}