using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public interface IUserQueryRepository<TUserDto> : IModelQueryRepository<TUserDto>,
        IQueryRepository<LoginQuery, LoginDto>,
        IQueryRepository<UserInfoQuery, UserInfoDto>
        where TUserDto : UserDto
    {
    }
}