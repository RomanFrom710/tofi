using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TOFI.Web.Auth
{
    public class AuthUser : IUser<string>
    {
        public string Id { get; set; }

        public string UserName
        {
            get { return Email; } set { Email = value; }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var user = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return user;
        }
    }
}
