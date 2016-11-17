using BLL.Services.Model;
using BLL.Services.User.ViewModels;

namespace BLL.Services.User
{
    public interface IUserService<TUserView> : IModelService<TUserView>
        where TUserView : UserViewModel
    {
    }


    public interface IUserService : IUserService<UserViewModel>
    {
    }
}