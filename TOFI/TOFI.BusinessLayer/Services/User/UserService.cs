using BLL.Services.Model;
using BLL.Services.User.ViewModels;
using DAL.Repositories.User;
using TOFI.TransferObjects.User.DataObjects;

namespace BLL.Services.User
{
    public abstract class UserService<TUserDto, TUserView> : ModelService<TUserDto, TUserView>, IUserService<TUserView>
        where TUserDto : UserDto where TUserView : UserViewModel
    {
        private readonly IUserQueryRepository<TUserDto> _queryRepository;
        private readonly IUserCommandRepository<TUserDto> _commandRepository;


        protected UserService(IUserQueryRepository<TUserDto> queryRepository,
            IUserCommandRepository<TUserDto> commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }


    public class UserService : UserService<UserDto, UserViewModel>, IUserService
    {
        private readonly IUserQueryRepository _queryRepository;
        private readonly IUserCommandRepository _commandRepository;


        public UserService(IUserQueryRepository queryRepository,
            IUserCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}