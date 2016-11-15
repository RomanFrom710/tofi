using BLL.Services.Auth;
using BLL.Services.User.ViewModels;
using DAL.Repositories.Model;
using TOFI.TransferObjects.User.DataObjects;

namespace BLL.Services.User
{
    public abstract class UserService<TUserDto, TUserView> : AuthService<TUserDto, TUserView>, IUserService
        where TUserDto : UserDto where TUserView : UserViewModel
    {
        protected UserService(IModelQueryRepository<TUserDto> queryRepository,
            IModelCommandRepository<TUserDto> commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}