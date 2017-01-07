using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;

namespace DAL.Repositories.Client
{
    public class ClientQueryRepository : ModelQueryRepository<ClientModel, ClientDto>, IClientQueryRepository
    {
        public ClientQueryRepository(TofiContext context) : base(context)
        {
        }


        public ClientDto Handle(ClientQuery query)
        {
            ClientModel model = null;
            if (query.Id.HasValue)
            {
                model = ModelsDao.Find(query.Id.Value);
            }
            if (query.UserId.HasValue)
            {
                model = ModelsDao.FirstOrDefault(c => c.User.Id == query.UserId);
            }
            return model == null ? null : Mapper.Map<ClientDto>(model);
        }

        public async Task<ClientDto> HandleAsync(ClientQuery query)
        {
            ClientModel model = null;
            if (query.Id.HasValue)
            {
                model = await ModelsDao.FindAsync(query.Id.Value);
            }
            if (query.UserId.HasValue)
            {
                model = await ModelsDao.FirstOrDefaultAsync(c => c.User.Id == query.UserId);
            }
            return model == null ? null : Mapper.Map<ClientDto>(model);
        }
    }
}