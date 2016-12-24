using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace DAL.Repositories.User
{
    public interface IUserCommandRepository : IModelCommandRepository<UserDto>
    {
    }
}