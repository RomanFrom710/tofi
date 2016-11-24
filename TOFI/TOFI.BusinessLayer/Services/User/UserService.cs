using AutoMapper;
using BLL.Result;
using BLL.Services.Auth;
using BLL.Services.Model;
using BLL.Services.User.ViewModels;
using DAL.Repositories.User;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace BLL.Services.User
{
    public abstract class UserService<TUserDto, TUserView> : ModelService<TUserDto, TUserView>, IUserService<TUserDto, TUserView>
        where TUserDto : UserDto where TUserView : UserViewModel
    {
        private readonly IUserQueryRepository<TUserDto> _queryRepository;
        private readonly IUserCommandRepository<TUserDto> _commandRepository;


        protected IAuthService AuthService { get; private set; }


        protected UserService(IUserQueryRepository<TUserDto> queryRepository,
            IUserCommandRepository<TUserDto> commandRepository, IAuthService authService)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            AuthService = authService;
        }


        public ServiceResult Register(RegisterViewModel model)
        {
            var userDto = Mapper.Map<TUserDto>(model);
            var authResult = AuthService.GetNewAuth(model.Password);
            if (authResult.IsFailed)
            {
                return new ServiceResult(false).From(authResult);
            }
            userDto.Auth = authResult.Value;
            var createResult = CreateModel(userDto);
            model.Id = userDto.Id;
            return new ServiceResult(createResult.ExecutionComleted).From(createResult);
        }

        public ValueResult<bool> Authenticate(UserQuery query, string password)
        {
            var userResult = RunQuery<UserQuery, TUserDto>(_queryRepository, query);
            return userResult.IsFailed
                ? new ValueResult<bool>(false, false).From(userResult)
                : AuthService.Authenticate(password, userResult.Value.Auth);
        }

        public QueryResult<TUserDto> GetUserDto(UserQuery query)
        {
            return RunQuery<UserQuery, TUserDto>(_queryRepository, query);
        }

        public QueryResult<TUserView> GetUser(UserQuery query)
        {
            return RunQuery<UserQuery, TUserDto>(_queryRepository, query).MapTo<TUserView>();
        }
    }


    public class UserService : UserService<UserDto, UserViewModel>, IUserService
    {
        private readonly IUserQueryRepository _queryRepository;
        private readonly IUserCommandRepository _commandRepository;


        public UserService(IUserQueryRepository queryRepository,
            IUserCommandRepository commandRepository, IAuthService authService)
            : base(queryRepository, commandRepository, authService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}