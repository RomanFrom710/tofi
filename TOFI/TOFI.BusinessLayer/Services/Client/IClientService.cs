using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Client.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;

namespace BLL.Services.Client
{
    public interface IClientService : IModelService<ClientDto, ClientViewModel>
    {
        QueryResult<ClientDto> GetClientDto(ClientQuery query);

        Task<QueryResult<ClientDto>> GetClientDtoAsync(ClientQuery query);

        QueryResult<ClientViewModel> GetClient(ClientQuery query);

        Task<QueryResult<ClientViewModel>> GetClientAsync(ClientQuery query);


        CommandResult AddOrUpdateClient(ClientViewModel client);

        Task<CommandResult> AddOrUpdateClientAsync(ClientViewModel client);


        ValueResult<bool> CanAddCreditRequest(int clientId);

        ValueResult<bool> ValidateClientInfo(ClientViewModel client);
    }
}