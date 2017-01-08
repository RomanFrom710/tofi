using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.Client;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

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
            if (!string.IsNullOrEmpty(query.PassportNumber))
            {
                model = ModelsDao.FirstOrDefault(c => c.PassportNumber == query.PassportNumber);
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
            if (!string.IsNullOrEmpty(query.PassportNumber))
            {
                model = await ModelsDao.FirstOrDefaultAsync(c => c.PassportNumber == query.PassportNumber);
            }
            return model == null ? null : Mapper.Map<ClientDto>(model);
        }

        public IEnumerable<CreditAccountDto> Handle(ClientAccountsQuery query)
        {
            var client = ModelsDao.Find(query.ClientId);
            return client?.CreditAccounts.MapTo<CreditAccountDto>() ?? Enumerable.Empty<CreditAccountDto>();
        }

        public async Task<IEnumerable<CreditAccountDto>> HandleAsync(ClientAccountsQuery query)
        {
            var client = await ModelsDao.FindAsync(query.ClientId);
            return client?.CreditAccounts.MapTo<CreditAccountDto>() ?? Enumerable.Empty<CreditAccountDto>();
        }
    }
}