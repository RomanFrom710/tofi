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

        QueryResult<TUserDto> GetUserDto(UserQuery query);

        QueryResult<TUserView> GetUser(UserQuery query);
    }


    public interface IUserService : IUserService<UserDto, UserViewModel>
    {
    }
}