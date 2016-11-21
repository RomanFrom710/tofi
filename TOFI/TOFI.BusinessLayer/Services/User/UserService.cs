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
            if (model.Password != model.ConfirmPassword)
            {
                return new ServiceResult(false).Error("Password and ConfirmPassword should be equal");
            }

            var userDto = Mapper.Map<TUserDto>(model);
            var authResult = AuthService.GetNewAuth(model.Password);
            if (!authResult.ExecutionComleted || authResult.IsError)
            {
                return new ServiceResult(authResult.ExecutionComleted)
                {
                    Message = authResult.Message,
                    Exception = authResult.Exception,
                    Severity = authResult.Severity
                };
            }
            userDto.Auth = authResult.Value;
            var createResult = CreateModel(userDto);
            return new ServiceResult(createResult.ExecutionComleted)
            {
                Message = createResult.Message,
                Exception = createResult.Exception,
                Severity = createResult.Severity
            };
        }

        public ValueResult<bool> Authenticate(UserQuery query, string password)
        {
            var userResult = RunQuery<UserQuery, TUserDto>(_queryRepository, query);
            if (!userResult.ExecutionComleted || userResult.IsError)
            {
                return new ValueResult<bool>(false, false)
                {
                    Exception = userResult.Exception,
                    Severity = userResult.Severity,
                    Message = userResult.Message
                };
            }
            return AuthService.Authenticate(password, userResult.Value.Auth);
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