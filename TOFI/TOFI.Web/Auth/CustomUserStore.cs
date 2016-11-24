using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using BLL.Services.Auth;
using BLL.Services.Security;
using BLL.Services.User;
using BLL.Services.User.ViewModels;
using Microsoft.AspNet.Identity;
using Ninject;
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
        private static AuthUser _user;

        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ISecurityService _securityService;

        public CustomUserStore()
        { // There is complicated classes hierarchy with all that asp.net stuff. Too lazy to use DI here
            _authService = DependencyResolver.Current.GetService<IAuthService>();
            _userService = DependencyResolver.Current.GetService<IUserService>();
            _securityService = DependencyResolver.Current.GetService<ISecurityService>();
        }

        public Task CreateAsync(AuthUser user)
        {
            var registerViewModel = Mapper.Map<RegisterViewModel>(user);
            var result = _userService.Register(registerViewModel);
            return Task.FromResult(result.ExecutionComleted);
        }

        public Task UpdateAsync(AuthUser user)
        {
            _user = user;
            return Task.FromResult(0);
        }

        public Task DeleteAsync(AuthUser user)
        {
            _user = null;
            return Task.FromResult(0);
        }

        public Task<AuthUser> FindByIdAsync(string userId)
        {
            _userService.GetModel(new ModelQuery { Id = int.Parse(userId) });
            return Task.FromResult(_user);
        }

        public Task<AuthUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(_user);
        }
        public void Dispose()
        { }

        #region password
        public Task SetPasswordHashAsync(AuthUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(AuthUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(AuthUser user)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.Password));
        }
        #endregion

        #region email
        public Task SetEmailAsync(AuthUser user, string email)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(AuthUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(AuthUser user)
        {
            return Task.FromResult(true);
        }

        public Task SetEmailConfirmedAsync(AuthUser user, bool confirmed)
        {
            return Task.FromResult(0);
        }

        public Task<AuthUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(_user);
        }
        #endregion

        #region Not needed lockout stuff
        // It's not used in our app, but somewhy .NET wants us to implement it.
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
    }
}