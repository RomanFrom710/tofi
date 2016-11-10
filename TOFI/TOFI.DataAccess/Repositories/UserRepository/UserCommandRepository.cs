using DAL.Contexts;
using DAL.Models.User;

namespace DAL.Repositories.UserRepository
{
    public class UserCommandRepository : ModelRepository<UserModel>, IUserCommandRepository
    {
        public UserCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}