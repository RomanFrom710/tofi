using BLL.Services.Model;
using BLL.Services.User.ViewModels;
using DAL.Repositories.User;
using TOFI.TransferObjects.User.DataObjects;

namespace BLL.Services.User
{
    public class UserService : ModelService<UserDto, UserViewModel>, IUserService
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