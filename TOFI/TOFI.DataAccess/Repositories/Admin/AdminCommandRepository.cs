using DAL.Contexts;
using DAL.Models.Admin;
using DAL.Repositories.User;

namespace DAL.Repositories.Admin
{
    public class AdminCommandRepository : UserCommandRepository<AdminModel>, IAdminCommandRepository
    {
        public AdminCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}