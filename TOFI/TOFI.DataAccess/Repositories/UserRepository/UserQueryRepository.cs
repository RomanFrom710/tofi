using DAL.Contexts;
using DAL.Models.User;

namespace DAL.Repositories.UserRepository
{
    public class UserQueryRepository : ModelRepository<UserModel>, IUserQueryRepository
    {
        public UserQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}