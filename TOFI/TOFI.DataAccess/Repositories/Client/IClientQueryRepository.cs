using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;

namespace DAL.Repositories.Client
{
    public interface IClientQueryRepository : IModelQueryRepository<ClientDto>,
        IQueryRepository<ClientQuery, ClientDto>
    {
    }
}