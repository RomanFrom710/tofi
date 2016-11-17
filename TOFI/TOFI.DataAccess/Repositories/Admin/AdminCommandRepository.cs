using DAL.Contexts;
using DAL.Models.Admin;
using DAL.Repositories.User;
using TOFI.TransferObjects.Admin.DataObjects;

namespace DAL.Repositories.Admin
{
    public class AdminCommandRepository : UserCommandRepository<AdminModel, AdminDto>, IAdminCommandRepository
    {
        public AdminCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}