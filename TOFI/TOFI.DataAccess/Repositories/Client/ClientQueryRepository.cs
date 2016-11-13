using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.User;

namespace DAL.Repositories.Client
{
    public class ClientQueryRepository : UserQueryRepository<ClientModel>, IClientQueryRepository
    {
        public ClientQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}