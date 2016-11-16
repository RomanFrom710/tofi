using BLL.Services.Auth.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Auth;
using TOFI.TransferObjects.Auth.DataObjects;

namespace BLL.Services.Auth
{
    public class AuthService : ModelService<AuthDto, AuthViewModel>, IAuthService<AuthViewModel>
    {
        private readonly IAuthQueryRepository<AuthDto> _queryRepository;
        private readonly IAuthCommandRepository<AuthDto> _commandRepository;


        public AuthService(IAuthQueryRepository<AuthDto> queryRepository,
            IAuthCommandRepository<AuthDto> commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}