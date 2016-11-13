using DAL.Contexts;
using DAL.Models.Admin;
using DAL.Repositories.User;

namespace DAL.Repositories.Admin
{
    public class AdminQueryRepository : UserQueryRepository<AdminModel>, IAdminQueryRepository
    {
        public AdminQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}