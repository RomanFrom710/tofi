using DAL.Repositories.Auth;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public interface IUserQueryRepository<TUserDto> : IAuthQueryRepository<TUserDto>,
        IQueryRepository<UserInfoQuery, UserInfoDto>
        where TUserDto : UserDto
    {
    }
}