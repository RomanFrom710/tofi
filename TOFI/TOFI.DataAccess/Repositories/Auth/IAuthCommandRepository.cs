using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;

namespace DAL.Repositories.Auth
{
    public interface IAuthCommandRepository : IModelCommandRepository<AuthDto>
    {
    }
}