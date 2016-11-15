using BLL.Services.Client.ViewModels;
using BLL.Services.User;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;

namespace BLL.Services.Client
{
    public class ClientService : UserService<ClientDto, ClientViewModel>, IClientService
    {
        public ClientService(IModelQueryRepository<ClientDto> queryRepository,
            IModelCommandRepository<ClientDto> commandRepository) : base(queryRepository, commandRepository)
        {
        }
    }
}