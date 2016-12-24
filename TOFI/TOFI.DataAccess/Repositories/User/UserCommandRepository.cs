using DAL.Contexts;
using DAL.Models.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public class UserCommandRepository : ModelCommandRepository<UserModel, UserDto>, IUserCommandRepository
    {
        public UserCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}