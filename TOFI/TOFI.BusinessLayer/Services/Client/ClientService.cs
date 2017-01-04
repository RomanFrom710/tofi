using System;
using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Client.ViewModels;
using BLL.Services.Model;
using BLL.Services.User;
using BLL.Services.User.ViewModels;
using DAL.Repositories.Client;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.User.Queries;

namespace BLL.Services.Client
{
    public class ClientService : ModelService<ClientDto, ClientViewModel>, IClientService
    {
        private readonly IClientQueryRepository _queryRepository;
        private readonly IClientCommandRepository _commandRepository;
        private readonly IUserService _userService;


        public ClientService(IClientQueryRepository queryRepository, IClientCommandRepository commandRepository,
            IUserService userService) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _userService = userService;
        }


        public QueryResult<ClientViewModel> GetClient(ClientQuery query)
        {
            QueryResult<UserViewModel> userRes = null;
            if (query.Id.HasValue)
            {
                userRes = _userService.GetUser(new UserQuery {ClientId = query.Id});
            }
            if (query.UserId.HasValue)
            {
                userRes = _userService.GetUser(new UserQuery {Id = query.UserId});
            }
            if (userRes == null)
            {
                return new QueryResult<ClientViewModel>(query, null, false).Error("Invalid query");
            }
            if (userRes.IsFailed)
            {
                return new QueryResult<ClientViewModel>(query, null, false).From(userRes);
            }
            var client = userRes.Value?.Client ?? new ClientViewModel();
            client.FirstName = userRes.Value?.FirstName;
            client.LastName = userRes.Value?.LastName;
            client.MiddleName = userRes.Value?.MiddleName;
            return new QueryResult<ClientViewModel>(query, client, true);
        }

        public async Task<QueryResult<ClientViewModel>> GetClientAsync(ClientQuery query)
        {
            QueryResult<UserViewModel> userRes = null;
            if (query.Id.HasValue)
            {
                userRes = await _userService.GetUserAsync(new UserQuery {ClientId = query.Id});
            }
            if (query.UserId.HasValue)
            {
                userRes = await _userService.GetUserAsync(new UserQuery {Id = query.UserId});
            }
            if (userRes == null)
            {
                return new QueryResult<ClientViewModel>(query, null, false).Error("Invalid query");
            }
            if (userRes.IsFailed)
            {
                return new QueryResult<ClientViewModel>(query, null, false).From(userRes);
            }
            if (userRes.Value == null)
            {
                return new QueryResult<ClientViewModel>(query, null, false).Error("Invalid user Id");
            }
            var client = userRes.Value?.Client ?? new ClientViewModel();
            client.FirstName = userRes.Value?.FirstName;
            client.LastName = userRes.Value?.LastName;
            client.MiddleName = userRes.Value?.MiddleName;
            return new QueryResult<ClientViewModel>(query, client, true);
        }


        public CommandResult UpdateClient(int userId, ClientViewModel client)
        {
            var userRes = _userService.GetUser(new UserQuery {Id = userId});
            if (userRes.IsFailed)
            {
                return new CommandResult(null, false).From(userRes);
            }
            if (userRes.Value == null)
            {
                return new CommandResult(null, false).Error("Invalid user Id");
            }
            var user = userRes.Value;
            user.FirstName = client?.FirstName ?? user.FirstName;
            user.LastName = client?.LastName ?? user.LastName;
            user.MiddleName = client?.MiddleName ?? user.MiddleName;
            user.Client = client;
            return _userService.UpdateModel(user);
        }

        public async Task<CommandResult> UpdateClientAsync(int userId, ClientViewModel client)
        {
            var userRes = await _userService.GetUserAsync(new UserQuery {Id = userId});
            if (userRes.IsFailed)
            {
                return new CommandResult(null, false).From(userRes);
            }
            if (userRes.Value == null)
            {
                return new CommandResult(null, false).Error("Invalid user Id");
            }
            var user = userRes.Value;
            user.FirstName = client?.FirstName ?? user.FirstName;
            user.LastName = client?.LastName ?? user.LastName;
            user.MiddleName = client?.MiddleName ?? user.MiddleName;
            user.Client = client;
            return await _userService.UpdateModelAsync(user);
        }


        public ValueResult<bool> CanAddCreditRequest(int userId)
        {
            var clientRes = GetClient(new ClientQuery {UserId = userId});
            if (clientRes.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(clientRes);
            }
            return ValidateClientInfo(clientRes.Value);
        }

        public ValueResult<bool> ValidateClientInfo(ClientViewModel client)
        {
            try
            {
                var msg = ValidateClientInner(client);
                if (!string.IsNullOrEmpty(msg))
                {
                    return new ValueResult<bool>(false, true).Error(msg);
                }
                return new ValueResult<bool>(true, true);
            }
            catch (Exception ex)
            {
                return new ValueResult<bool>(false, false).Fatal($"Unhandled exception: {ex.Message}", ex);
            }
        }


        private string ValidateClientInner(ClientViewModel client)
        {
            if (client == null)
                return "Client info not filled";
            if (string.IsNullOrWhiteSpace(client.FirstName))
                return "First Name not filled";
            if (string.IsNullOrWhiteSpace(client.LastName))
                return "Last Name not filled";
            if (string.IsNullOrWhiteSpace(client.MiddleName))
                return "Middle Name not filled";
            if (string.IsNullOrWhiteSpace(client.Address))
                return "Address not filled";
            if (string.IsNullOrWhiteSpace(client.TelephoneNumber))
                return "Telephone Number not filled";
            if (string.IsNullOrWhiteSpace(client.PassportNumber))
                return "Passport Number not filled";
            if (string.IsNullOrWhiteSpace(client.PassportId))
                return "Passport Id not filled";
            if (string.IsNullOrWhiteSpace(client.Authority))
                return "Authority not filled";
            if (!client.Birthday.HasValue)
                return "Birthday is not filled";
            var age = (int) Math.Floor((DateTime.Now.Date - client.Birthday.Value.Date).TotalDays/365);
            if (age < 18)
                return "You are too young to take credits.";
            if (age > 150)
                return "People normally don't live that long.";
            if (!client.IssueDate.HasValue)
                return "Issue Date is not filled";
            if (DateTime.Now.Date < client.IssueDate)
                return "Your passport is from future. Sorry, but we can't accept it.";
            if (!client.ExpirationDate.HasValue)
                return "Expiration Date is not filled";
            if (DateTime.Now.Date > client.ExpirationDate)
                return "Your passport is outdated. Go get a new one.";
            return string.Empty;
        }
    }
}