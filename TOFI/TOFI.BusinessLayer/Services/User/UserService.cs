using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Model;
using BLL.Services.Signature;
using BLL.Services.User.ViewModels;
using DAL.Repositories.User;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace BLL.Services.User
{
    public class UserService : ModelService<UserDto, UserViewModel>, IUserService
    {
        private readonly IUserQueryRepository _queryRepository;
        private readonly IUserCommandRepository _commandRepository;
        private readonly ISignatureService _signatureService;


        public UserService(IUserQueryRepository queryRepository, IUserCommandRepository commandRepository,
            ISignatureService signatureService) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _signatureService = signatureService;
        }


        public override CommandResult CreateModel(UserDto dto)
        {
            dto.Key = _signatureService.GenerateNewKey().Value;
            return base.CreateModel(dto);
        }

        public override Task<CommandResult> CreateModelAsync(UserDto dto)
        {
            dto.Key = _signatureService.GenerateNewKey().Value;
            return base.CreateModelAsync(dto);
        }

        public override CommandResult CreateModel(UserViewModel viewModel)
        {
            viewModel.Key = _signatureService.GenerateNewKey().Value;
            return base.CreateModel(viewModel);
        }

        public override Task<CommandResult> CreateModelAsync(UserViewModel viewModel)
        {
            viewModel.Key = _signatureService.GenerateNewKey().Value;
            return base.CreateModelAsync(viewModel);
        }

        public QueryResult<UserDto> GetUserDto(UserQuery query)
        {
            return RunQuery<UserQuery, UserDto>(_queryRepository, query);
        }

        public async Task<QueryResult<UserDto>> GetUserDtoAsync(UserQuery query)
        {
            return await RunQueryAsync<UserQuery, UserDto>(_queryRepository, query);
        }

        public QueryResult<UserViewModel> GetUser(UserQuery query)
        {
            return RunQuery<UserQuery, UserDto>(_queryRepository, query).MapTo<UserViewModel>();
        }

        public async Task<QueryResult<UserViewModel>> GetUserAsync(UserQuery query)
        {
            return (await RunQueryAsync<UserQuery, UserDto>(_queryRepository, query)).MapTo<UserViewModel>();
        }
    }
}