using BLL.Services.Client.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Client;
using TOFI.TransferObjects.Client.DataObjects;

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
    }
}