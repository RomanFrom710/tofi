using System.Threading.Tasks;
using BLL.Result;
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


        protected UserService(IUserQueryRepository<TUserDto> queryRepository,
            IUserCommandRepository<TUserDto> commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }


        public QueryResult<TUserDto> GetUserDto(UserQuery query)
        {
            return RunQuery<UserQuery, TUserDto>(_queryRepository, query);
        }

        public async Task<QueryResult<TUserDto>> GetUserDtoAsync(UserQuery query)
        {
            return await RunQueryAsync<UserQuery, TUserDto>(_queryRepository, query);
        }

        public QueryResult<TUserView> GetUser(UserQuery query)
        {
            return RunQuery<UserQuery, TUserDto>(_queryRepository, query).MapTo<TUserView>();
        }

        public async Task<QueryResult<TUserView>> GetUserAsync(UserQuery query)
        {
            return (await RunQueryAsync<UserQuery, TUserDto>(_queryRepository, query)).MapTo<TUserView>();
        }
    }


    public class UserService : UserService<UserDto, UserViewModel>, IUserService
    {
        private readonly IUserQueryRepository _queryRepository;
        private readonly IUserCommandRepository _commandRepository;


        public UserService(IUserQueryRepository queryRepository, IUserCommandRepository commandRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}