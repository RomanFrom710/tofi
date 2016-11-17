using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.User;
using TOFI.TransferObjects.Client.DataObjects;

namespace DAL.Repositories.Client
{
    public class ClientCommandRepository : UserCommandRepository<ClientModel, ClientDto>, IClientCommandRepository
    {
        public ClientCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}