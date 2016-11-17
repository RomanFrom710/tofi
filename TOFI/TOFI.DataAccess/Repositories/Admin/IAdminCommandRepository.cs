using DAL.Repositories.User;
using TOFI.TransferObjects.Admin.DataObjects;

namespace DAL.Repositories.Admin
{
    public interface IAdminCommandRepository : IUserCommandRepository<AdminDto>
    {
    }
}