using DAL.Contexts;
using DAL.Models.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public abstract class UserQueryRepository<TUser, TUserDto> : ModelQueryRepository<TUser, TUserDto>, IUserQueryRepository<TUserDto>
        where TUser : UserModel where TUserDto : UserDto
    {
        protected UserQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}