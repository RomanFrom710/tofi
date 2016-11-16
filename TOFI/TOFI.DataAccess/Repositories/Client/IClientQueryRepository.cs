using DAL.Repositories.Model;
using TOFI.TransferObjects.Client.DataObjects;

namespace DAL.Repositories.Client
{
    public interface IClientQueryRepository : IModelQueryRepository<ClientDto>
    {
    }
}