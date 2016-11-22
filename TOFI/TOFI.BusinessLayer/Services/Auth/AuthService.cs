using System;
using BLL.Result;
using BLL.Services.Auth.ViewModels;
using BLL.Services.Model;
using BLL.Services.Security;
using DAL.Repositories.Auth;
using TOFI.TransferObjects.Auth.DataObjects;

namespace BLL.Services.Auth
{
    public class AuthService : ModelService<AuthDto, AuthViewModel>, IAuthService
    {
        public const int MaxAccessFailedCnt = 7;


        public static readonly TimeSpan LockoutTime = TimeSpan.FromMinutes(30);


        private readonly IAuthQueryRepository _queryRepository;
        private readonly IAuthCommandRepository _commandRepository;
        private readonly ISecurityService _securityService;


        public AuthService(IAuthQueryRepository queryRepository,
            IAuthCommandRepository commandRepository, ISecurityService securityService)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _securityService = securityService;
        }


        public ValueResult<AuthDto> GetNewAuth(string password)
        {
            try
            {
                var auth = new AuthDto {Salt = _securityService.GetNewSalt()};
                auth.PasswordHash = _securityService.ApplySalt(password, auth.Salt);
                return new ValueResult<AuthDto>(auth);
            }
            catch (Exception ex)
            {
                return FatalResult<AuthDto>(null, $"Unhandled exception: {ex.Message}", ex);
            }
        }

        public ValueResult<bool> Authenticate(string password, AuthDto auth)
        {
            if (auth.LockoutDateUtc > DateTime.UtcNow)
                return new ValueResult<bool>(false).Error("User locked out");

            var passwordHash = _securityService.ApplySalt(password, auth.Salt);
            var correctPassword = passwordHash == auth.PasswordHash;
            string message = null;
            if (correctPassword)
            {
                auth.AccessGrantedTotal++;
                auth.LastAccessGrantedDateUtc = DateTime.UtcNow;
                auth.AccessFailedCnt = 0;
            }
            else
            {
                message = "Invalid password";
                auth.AccessFailedTotal++;
                auth.LastAccessFailedDateUtc = DateTime.UtcNow;
                auth.AccessFailedCnt++;
                if (auth.AccessFailedCnt >= MaxAccessFailedCnt)
                {
                    auth.LockoutDateUtc = DateTime.UtcNow + LockoutTime;
                    auth.AccessFailedCnt = 0;
                    message = "User locked out";
                }
            }
            var updateResult = UpdateModel(auth);
            if (updateResult.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(updateResult);
            }
            return string.IsNullOrEmpty(message)
                ? new ValueResult<bool>(correctPassword)
                : new ValueResult<bool>(correctPassword).Error(message);
        }
    }
}