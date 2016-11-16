using BLL.Services.Client.ViewModels;
using BLL.Services.User;
using DAL.Repositories.Client;
using TOFI.TransferObjects.Client.DataObjects;

namespace BLL.Services.Client
{
    public class ClientService : UserService<ClientDto, ClientViewModel>, IClientService
    {
        public ClientService(IClientQueryRepository queryRepository,
            IClientCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}