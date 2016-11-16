using BLL.Services.Auth.ViewModels;
using BLL.Services.Model;

namespace BLL.Services.Auth
{
    public interface IAuthService<TAuthView> : IModelService<TAuthView> 
        where TAuthView : AuthViewModel
    {
    }
}