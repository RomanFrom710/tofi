using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.UserRole;
using Microsoft.AspNet.Identity;

namespace TOFI.Web.Auth
{
    public class CustomRoleStore : IQueryableRoleStore<UserRole>
    {
        public IQueryable<UserRole> Roles => UserRoleService.All.Select(r => new UserRole {Name = r}).AsQueryable();


        public void Dispose()
        {
        }

        public Task CreateAsync(UserRole role)
        {
            throw new NotSupportedException();
        }

        public Task UpdateAsync(UserRole role)
        {
            throw new NotSupportedException();
        }

        public Task DeleteAsync(UserRole role)
        {
            throw new NotSupportedException();
        }

        public Task<UserRole> FindByIdAsync(string roleId)
        {
            return UserRoleService.All.Contains(roleId)
                ? Task.FromResult(new UserRole {Name = roleId})
                : Task.FromResult<UserRole>(null);
        }

        public Task<UserRole> FindByNameAsync(string roleName)
        {
            return UserRoleService.All.Contains(roleName)
                ? Task.FromResult(new UserRole {Name = roleName})
                : Task.FromResult<UserRole>(null);
        }
    }
}