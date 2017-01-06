using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.UserRole
{
    public interface IUserRoleService
    {
        Task<IList<string>> GetRoles(int userId);

        Task<bool> IsInRole(int userId, string role);

        Task AddToRole(int userId, string role);

        Task RemoveFromRole(int userId, string role);
    }
}