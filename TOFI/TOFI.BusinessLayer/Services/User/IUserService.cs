using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Model;
using BLL.Services.User.ViewModels;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace BLL.Services.User
{
    public interface IUserService : IModelService<UserDto, UserViewModel>
    {
        QueryResult<UserDto> GetUserDto(UserQuery query);

        Task<QueryResult<UserDto>> GetUserDtoAsync(UserQuery query);

        QueryResult<UserViewModel> GetUser(UserQuery query);

        Task<QueryResult<UserViewModel>> GetUserAsync(UserQuery query);
    }
}