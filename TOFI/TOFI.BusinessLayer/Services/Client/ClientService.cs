using System;
using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Client.ViewModels;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Client;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace BLL.Services.Client
{
    public class ClientService : ModelService<ClientDto, ClientViewModel>, IClientService
    {
        private readonly IClientQueryRepository _queryRepository;
        private readonly IClientCommandRepository _commandRepository;


        public ClientService(IClientQueryRepository queryRepository, IClientCommandRepository commandRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }


        public QueryResult<ClientDto> GetClientDto(ClientQuery query)
        {
            return RunQuery<ClientQuery, ClientDto>(_queryRepository, query);
        }

        public async Task<QueryResult<ClientDto>> GetClientDtoAsync(ClientQuery query)
        {
            return await RunQueryAsync<ClientQuery, ClientDto>(_queryRepository, query);
        }

        public QueryResult<ClientViewModel> GetClient(ClientQuery query)
        {
            return RunQuery<ClientQuery, ClientDto>(_queryRepository, query).MapTo<ClientViewModel>();
        }

        public async Task<QueryResult<ClientViewModel>> GetClientAsync(ClientQuery query)
        {
            return (await RunQueryAsync<ClientQuery, ClientDto>(_queryRepository, query)).MapTo<ClientViewModel>();
        }


        public CommandResult AddOrUpdateClient(ClientViewModel client)
        {
            var clientRes = GetClientDto(ClientQuery.WithUserId(client.User.Id));
            if (clientRes.IsFailed)
            {
                return new CommandResult(null, false).From(clientRes);
            }
            return clientRes.Value == null ? CreateModel(client) : UpdateModel(client);
        }

        public async Task<CommandResult> AddOrUpdateClientAsync(ClientViewModel client)
        {
            var clientRes = await GetClientDtoAsync(ClientQuery.WithUserId(client.User.Id));
            if (clientRes.IsFailed)
            {
                return new CommandResult(null, false).From(clientRes);
            }
            return await (clientRes.Value == null ? CreateModelAsync(client) : UpdateModelAsync(client));
        }


        public ValueResult<bool> CanAddCreditRequest(int userId)
        {
            var clientRes = GetClient(ClientQuery.WithUserId(userId));
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
            var age = (int)Math.Floor((DateTime.Now.Date - client.Birthday.Value.Date).TotalDays / 365);
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

        public ListQueryResult<CreditAccountDto> GetClientAccountsDto(ClientAccountsQuery query)
        {
            return RunListQuery<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditAccountDto>> GetClientAccountsDtoAsync(ClientAccountsQuery query)
        {
            return await RunListQueryAsync<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditAccountViewModel> GetClientAccounts(ClientAccountsQuery query)
        {
            return RunListQuery<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query).MapTo<CreditAccountViewModel>();
        }

        public async Task<ListQueryResult<CreditAccountViewModel>> GetClientAccountsAsync(ClientAccountsQuery query)
        {
            return (await RunListQueryAsync<ClientAccountsQuery, CreditAccountDto>(_queryRepository, query)).MapTo<CreditAccountViewModel>();
        }
    }
}