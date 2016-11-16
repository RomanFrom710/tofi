using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public interface IUserQueryRepository : IModelQueryRepository<UserDto>,
        IQueryRepository<UserInfoQuery, UserInfoDto>
    {
    }
}