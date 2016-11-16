using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;

namespace DAL.Repositories.Client
{
    public class ClientQueryRepository : ModelQueryRepository<ClientModel, ClientDto>, IClientQueryRepository
    {
        public ClientQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}