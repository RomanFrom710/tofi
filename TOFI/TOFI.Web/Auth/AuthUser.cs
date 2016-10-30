using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TOFI.Web.Auth
{
    public class AuthUser : IUser<string>
    {
        public string Id { get; } = "1"; // todo: remove mock
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var user = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return user;
        }
    }
}
