using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Result;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Model.Queries;
using TOFI.TransferObjects.User.Queries;

namespace TOFI.Web.Auth
{
    public class CustomUserStore :
        IUserStore<AuthUser>,
        IUserPasswordStore<AuthUser>,
        IUserEmailStore<AuthUser>,
        IUserLockoutStore<AuthUser, string>,
        IUserTwoFactorStore<AuthUser, string>
    {
        private readonly IUserService _userService;

        public CustomUserStore()
        { // There is complicated classes hierarchy with all that asp.net stuff. Too lazy to use DI here
            _userService = DependencyResolver.Current.GetService<IUserService>();
        }

        public Task CreateAsync(AuthUser user)
        {
            var result = _userService.CreateModel(user.Dto);
            return ProcessCommandResult(result);
        }

        public Task UpdateAsync(AuthUser user)
        {
            var result = _userService.UpdateModel(user.Dto);
            return ProcessCommandResult(result);
        }

        public Task DeleteAsync(AuthUser user)
        {
            var result = _userService.DeleteModel(user.Dto.Id);
            return ProcessCommandResult(result);
        }

        public Task<AuthUser> FindByIdAsync(string userId)
        {
            var result = _userService.GetModelDto(new ModelQuery {Id = int.Parse(userId)});
            return Task.FromResult(AuthUser.FromDto(ProcessQueryResult(result)));
        }

        public Task<AuthUser> FindByNameAsync(string userName)
        {
            var result = _userService.GetUserDto(new UserQuery { Email = userName});
            return Task.FromResult(AuthUser.FromDto(ProcessQueryResult(result)));
        }

        public void Dispose()
        {
            _userService.Dispose();
        }

        #region password

        public Task SetPasswordHashAsync(AuthUser user, string passwordHash)
        {
            var passwordParts = passwordHash.Split(' ');
            user.Dto.Auth.PasswordHash = passwordParts[0];
            user.Dto.Auth.Salt = passwordParts[1];
            return UpdateAsync(user);
        }

        public Task<string> GetPasswordHashAsync(AuthUser user)
        {
            return Task.FromResult($"{user.Dto.Auth.PasswordHash} {user.Dto.Auth.Salt}");
        }

        public Task<bool> HasPasswordAsync(AuthUser user)
        {
            return Task.FromResult(user.HasPassword);
        }

        #endregion

        #region email

        public Task SetEmailAsync(AuthUser user, string email)
        {
            user.Email = email;
            return UpdateAsync(user);
        }

        public Task<string> GetEmailAsync(AuthUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(AuthUser user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(AuthUser user, bool confirmed)
        {
            user.Dto.EmailConfirmed = confirmed;
            return UpdateAsync(user);
        }

        public Task<AuthUser> FindByEmailAsync(string email)
        {
            var result = _userService.GetUserDto(new UserQuery {Email = email});
            return Task.FromResult(AuthUser.FromDto(ProcessQueryResult(result)));
        }

        #endregion

        #region lockout
        
        public Task<DateTimeOffset> GetLockoutEndDateAsync(AuthUser user)
        {
            return Task.FromResult(DateTimeOffset.MinValue);
        }

        public Task SetLockoutEndDateAsync(AuthUser user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(AuthUser user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(AuthUser user)
        {
            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(AuthUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(AuthUser user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(AuthUser user, bool enabled)
        {
            return Task.FromResult(0);
        }

        #endregion

        #region two factor
        public Task SetTwoFactorEnabledAsync(AuthUser user, bool enabled)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(AuthUser user)
        {
            return Task.FromResult(false);
        }
        #endregion


        private Task ProcessCommandResult(CommandResult result)
        {
            if (result.IsFailed)
            {
                Debug.WriteLine(result.Message);
            }
            return Task.FromResult(result.ExecutionComleted);
        }

        private T ProcessQueryResult<T>(QueryResult<T> result)
        {
            if (result.IsFailed)
            {
                Debug.WriteLine(result.Message);
            }
            return result.Value;
        }
    }
}