using DAL.Repositories.Auth;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public interface IUserCommandRepository<TUserDto> : IAuthCommandRepository<TUserDto> 
        where TUserDto : UserDto
    {
    }
}