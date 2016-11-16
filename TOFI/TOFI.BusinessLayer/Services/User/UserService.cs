using BLL.Services.Model;
using BLL.Services.User.ViewModels;
using DAL.Repositories.User;
using TOFI.TransferObjects.User.DataObjects;

namespace BLL.Services.User
{
    public class UserService : ModelService<UserDto, UserViewModel>, IUserService<UserViewModel>
    {
        private readonly IUserQueryRepository<UserDto> _queryRepository;
        private readonly IUserCommandRepository<UserDto> _commandRepository;


        public UserService(IUserQueryRepository<UserDto> queryRepository,
            IUserCommandRepository<UserDto> commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}