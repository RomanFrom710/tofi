using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public interface IUserCommandRepository<TUserDto> : IModelCommandRepository<TUserDto>
        where TUserDto : UserDto
    {
    }


    public interface IUserCommandRepository : IUserCommandRepository<UserDto>
    {
    }
}