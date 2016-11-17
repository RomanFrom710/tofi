using DAL.Contexts;
using DAL.Models.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public abstract class UserCommandRepository<TUser, TUserDto> : ModelCommandRepository<TUser, TUserDto>, IUserCommandRepository<TUserDto>
        where TUser : UserModel, new() where TUserDto : UserDto
    {
        protected UserCommandRepository(TofiContext context) : base(context)
        {
        }
    }


    public class UserCommandRepository : UserCommandRepository<UserModel, UserDto>, IUserCommandRepository
    {
        public UserCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}