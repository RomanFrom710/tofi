using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;
using TOFI.TransferObjects.Auth.Queries;

namespace DAL.Repositories.Auth
{
    public interface IAuthQueryRepository : IModelQueryRepository<AuthDto>,
        IQueryRepository<LoginQuery, LoginDto>
    {
    }
}