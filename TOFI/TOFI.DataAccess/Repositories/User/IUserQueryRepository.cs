using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public interface IUserQueryRepository : IRepository,
        IQueryRepository<LoginQuery, LoginDto>,
        IQueryRepository<UserQuery, UserDto>
    {
    }
}