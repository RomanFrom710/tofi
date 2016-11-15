using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;
using TOFI.TransferObjects.Auth.Queries;

namespace DAL.Repositories.Auth
{
    public interface IAuthQueryRepository<TAuthDto> : IModelQueryRepository<TAuthDto>,
        IQueryRepository<LoginQuery, LoginDto>
        where TAuthDto : AuthDto
    {
    }
}