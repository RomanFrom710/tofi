using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public interface IUserQueryRepository<TUserDto> : IModelQueryRepository<TUserDto>
        where TUserDto : UserDto
    {
    }
}