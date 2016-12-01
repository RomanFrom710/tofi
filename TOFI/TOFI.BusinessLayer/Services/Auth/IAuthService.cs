using BLL.Services.Auth.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Auth.DataObjects;

namespace BLL.Services.Auth
{
    public interface IAuthService : IModelService<AuthDto, AuthViewModel>
    {
    }
}