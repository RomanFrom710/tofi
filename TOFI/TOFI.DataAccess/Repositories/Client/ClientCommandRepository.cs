using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.User;

namespace DAL.Repositories.Client
{
    public class ClientCommandRepository : UserCommandRepository<ClientModel>, IClientCommandRepository
    {
        public ClientCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}