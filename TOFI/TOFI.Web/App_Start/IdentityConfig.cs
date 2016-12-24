using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using TOFI.Web.Auth;

namespace TOFI.Web
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<AuthUser>
    {
        public ApplicationUserManager(IUserStore<AuthUser> store)
            : base(store)
        { }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new CustomUserStore());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AuthUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                //RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                //RequireUppercase = true,
            };
            manager.PasswordHasher = new CustomPasswordHasher();

            //manager.EmailService = new EmailService();

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(30);
            manager.MaxFailedAccessAttemptsBeforeLockout = 7;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<AuthUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }


        public override async Task<bool> CheckPasswordAsync(AuthUser user, string password)
        {
            var res = await base.CheckPasswordAsync(user, password);
            if (res)
            {
                user.Dto.Auth.AccessGrantedTotal++;
                user.Dto.Auth.LastAccessGrantedDateUtc = DateTime.UtcNow;
            }
            else
            {
                user.Dto.Auth.AccessFailedTotal++;
                user.Dto.Auth.LastAccessFailedDateUtc = DateTime.UtcNow;
            }
            await Store.UpdateAsync(user);
            return res;
        }
    }


    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<AuthUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }


    public class ApplicationRoleManager : RoleManager<UserRole>
    {
        public ApplicationRoleManager(IRoleStore<UserRole, string> store) : base(store)
        {
        }


        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            return new ApplicationRoleManager(new CustomRoleStore());
        }
    }
}