using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace DAL.Repositories.Client
{
    public interface IClientQueryRepository : IModelQueryRepository<ClientDto>,
        IQueryRepository<ClientQuery, ClientDto>,
        IListQueryRepository<ClientAccountsQuery, CreditAccountDto>
    {
    }
}