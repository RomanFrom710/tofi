using DAL.Contexts;
using DAL.Models.User;
using DAL.Repositories.Auth;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public abstract class UserCommandRepository<TUser, TUserDto> : AuthCommandRepository<TUser, TUserDto>, IUserCommandRepository<TUserDto>
        where TUser : UserModel, new() where TUserDto : UserDto
    {
        protected UserCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}