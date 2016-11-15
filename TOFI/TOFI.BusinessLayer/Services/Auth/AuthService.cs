using BLL.Services.Auth.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;

namespace BLL.Services.Auth
{
    public abstract class AuthService<TAuthDto, TAuthView> : ModelService<TAuthDto, TAuthView>, IAuthService
        where TAuthDto : AuthDto where TAuthView : AuthViewModel
    {
        protected AuthService(IModelQueryRepository<TAuthDto> queryRepository,
            IModelCommandRepository<TAuthDto> commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}