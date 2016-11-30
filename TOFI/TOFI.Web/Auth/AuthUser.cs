using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Auth.DataObjects;
using TOFI.TransferObjects.User.DataObjects;

namespace TOFI.Web.Auth
{
    public class AuthUser : IUser<string>
    {
        public string Id => Dto?.Id.ToString();

        public string UserName
        {
            get { return Email; }
            set { Email = value; }
        }

        public UserDto Dto { get; set; } = new UserDto {Auth = new AuthDto()};

        public string Email
        {
            get { return Dto?.Email; }
            set
            {
                if (Dto != null)
                {
                    Dto.Email = value;
                }
            }
        }

        public string FirstName
        {
            get { return Dto?.FirstName; }
            set
            {
                if (Dto != null)
                {
                    Dto.FirstName = value;
                }
            }
        }

        public string LastName
        {
            get { return Dto?.LastName; }
            set
            {
                if (Dto != null)
                {
                    Dto.LastName = value;
                }
            }
        }

        public bool EmailConfirmed => Dto?.EmailConfirmed ?? false;

        public bool HasPassword => !string.IsNullOrEmpty(Dto?.Auth?.PasswordHash);


        public static AuthUser FromDto(UserDto dto)
        {
            return dto != null ? new AuthUser {Dto = dto} : null;
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var user = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return user;
        }
    }
}