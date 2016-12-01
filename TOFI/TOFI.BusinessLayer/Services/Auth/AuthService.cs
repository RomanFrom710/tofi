using BLL.Services.Auth.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Auth;
using TOFI.TransferObjects.Auth.DataObjects;

namespace BLL.Services.Auth
{
    public class AuthService : ModelService<AuthDto, AuthViewModel>, IAuthService
    {
        private readonly IAuthQueryRepository _queryRepository;
        private readonly IAuthCommandRepository _commandRepository;


        public AuthService(IAuthQueryRepository queryRepository, IAuthCommandRepository commandRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}