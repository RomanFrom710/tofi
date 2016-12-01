using System.Threading.Tasks;
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
        QueryResult<TUserDto> GetUserDto(UserQuery query);

        Task<QueryResult<TUserDto>> GetUserDtoAsync(UserQuery query);

        QueryResult<TUserView> GetUser(UserQuery query);

        Task<QueryResult<TUserView>> GetUserAsync(UserQuery query);
    }


    public interface IUserService : IUserService<UserDto, UserViewModel>
    {
    }
}