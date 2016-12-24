using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TOFI.Web.Auth
{
    public class CustomRoleStore : IQueryableRoleStore<UserRole>
    {
        public IQueryable<UserRole> Roles => UserRoles.All.Select(r => new UserRole {Name = r}).AsQueryable();


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
            return UserRoles.All.Contains(roleId)
                ? Task.FromResult(new UserRole {Name = roleId})
                : Task.FromResult<UserRole>(null);
        }

        public Task<UserRole> FindByNameAsync(string roleName)
        {
            return UserRoles.All.Contains(roleName)
                ? Task.FromResult(new UserRole {Name = roleName})
                : Task.FromResult<UserRole>(null);
        }
    }
}