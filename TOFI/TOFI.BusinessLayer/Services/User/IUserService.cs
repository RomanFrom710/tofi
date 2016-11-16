using BLL.Services.Auth;
using BLL.Services.User.ViewModels;

namespace BLL.Services.User
{
    public interface IUserService<TUserView> : IAuthService<TUserView>
        where TUserView : UserViewModel
    {
    }
}