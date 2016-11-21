using BLL.Result;
using BLL.Services.Model;
using BLL.Services.User.ViewModels;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace BLL.Services.User
{
    public interface IUserService<TUserDto, TUserView> : IModelService<TUserDto, TUserView>
        where TUserDto : UserDto where TUserView : UserViewModel
    {
        ServiceResult Register(RegisterViewModel model);

        ValueResult<bool> Authenticate(UserQuery query, string password);
    }


    public interface IUserService : IUserService<UserDto, UserViewModel>
    {
    }
}