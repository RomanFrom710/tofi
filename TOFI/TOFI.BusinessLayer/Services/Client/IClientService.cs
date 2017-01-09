using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Client.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using BLL.Services.Credits.CreditAccount.ViewModels;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace BLL.Services.Client
{
    public interface IClientService : IModelService<ClientDto, ClientViewModel>
    {
        QueryResult<ClientDto> GetClientDto(ClientQuery query);

        Task<QueryResult<ClientDto>> GetClientDtoAsync(ClientQuery query);

        QueryResult<ClientViewModel> GetClient(ClientQuery query);

        Task<QueryResult<ClientViewModel>> GetClientAsync(ClientQuery query);


        ListQueryResult<CreditAccountDto> GetClientAccountsDto(ClientAccountsQuery query);

        Task<ListQueryResult<CreditAccountDto>> GetClientAccountsDtoAsync(ClientAccountsQuery query);

        ListQueryResult<CreditAccountViewModel> GetClientAccounts(ClientAccountsQuery query);

        Task<ListQueryResult<CreditAccountViewModel>> GetClientAccountsAsync(ClientAccountsQuery query);


        ListQueryResult<CreditTypeDto> GetCreditTypesDto(SelectCreditTypesQuery query);

        Task<ListQueryResult<CreditTypeDto>> GetCreditTypesDtoAsync(SelectCreditTypesQuery query);

        ListQueryResult<CreditTypeViewModel> GetCreditTypes(SelectCreditTypesQuery query);

        Task<ListQueryResult<CreditTypeViewModel>> GetCreditTypesAsync(SelectCreditTypesQuery query);


        CommandResult AddOrUpdateClient(ClientViewModel client);

        Task<CommandResult> AddOrUpdateClientAsync(ClientViewModel client);


        ValueResult<bool> CanAddCreditRequest(int userId);

        ValueResult<List<KeyValuePair<string, string>>> ValidateClientInfo(ClientViewModel client);
    }
}