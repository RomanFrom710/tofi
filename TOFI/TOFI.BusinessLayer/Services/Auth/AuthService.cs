using BLL.Services.Auth.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Auth;
using TOFI.TransferObjects.Auth.DataObjects;

namespace BLL.Services.Auth
{
    public abstract class AuthService<TAuthDto, TAuthView> : ModelService<TAuthDto, TAuthView>, IAuthService<TAuthView>
        where TAuthDto : AuthDto where TAuthView : AuthViewModel
    {
        protected AuthService(IAuthQueryRepository<TAuthDto> queryRepository,
            IAuthCommandRepository<TAuthDto> commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}