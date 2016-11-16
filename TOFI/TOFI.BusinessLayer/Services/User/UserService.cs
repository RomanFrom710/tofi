using BLL.Services.Auth;
using BLL.Services.User.ViewModels;
using DAL.Repositories.User;
using TOFI.TransferObjects.User.DataObjects;

namespace BLL.Services.User
{
    public abstract class UserService<TUserDto, TUserView> : AuthService<TUserDto, TUserView>, IUserService<TUserView>
        where TUserDto : UserDto where TUserView : UserViewModel
    {
        protected UserService(IUserQueryRepository<TUserDto> queryRepository,
            IUserCommandRepository<TUserDto> commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}