using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public interface IUserQueryRepository<TUserDto> : IModelQueryRepository<TUserDto>,
        IQueryRepository<UserQuery, TUserDto>
        where TUserDto : UserDto
    {
    }


    public interface IUserQueryRepository : IUserQueryRepository<UserDto>
    {
    }
}