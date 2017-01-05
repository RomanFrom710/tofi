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
        QueryResult<ClientViewModel> GetClient(ClientQuery query);

        Task<QueryResult<ClientViewModel>> GetClientAsync(ClientQuery query);


        CommandResult UpdateClient(int userId, ClientViewModel client);

        Task<CommandResult> UpdateClientAsync(int userId, ClientViewModel client);


        ValueResult<bool> CanAddCreditRequest(int clientId);

        ValueResult<bool> ValidateClientInfo(ClientViewModel client);
    }
}