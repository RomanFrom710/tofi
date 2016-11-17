using DAL.Contexts;
using DAL.Models.Admin;
using DAL.Repositories.User;
using TOFI.TransferObjects.Admin.DataObjects;

namespace DAL.Repositories.Admin
{
    public class AdminQueryRepository : UserQueryRepository<AdminModel, AdminDto>, IAdminQueryRepository
    {
        public AdminQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}