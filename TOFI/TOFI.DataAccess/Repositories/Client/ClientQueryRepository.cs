using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.User;
using TOFI.TransferObjects.Client.DataObjects;

namespace DAL.Repositories.Client
{
    public class ClientQueryRepository : UserQueryRepository<ClientModel, ClientDto>, IClientQueryRepository
    {
        public ClientQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}