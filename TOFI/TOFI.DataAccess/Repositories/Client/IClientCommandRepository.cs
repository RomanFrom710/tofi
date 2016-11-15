using DAL.Repositories.User;
using TOFI.TransferObjects.Client.DataObjects;

namespace DAL.Repositories.Client
{
    public interface IClientCommandRepository : IUserCommandRepository<ClientDto>
    {
    }
}