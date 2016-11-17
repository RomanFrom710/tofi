using DAL.Contexts;
using DAL.Models.Auth;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;

namespace DAL.Repositories.Auth
{
    public class AuthQueryRepository : ModelQueryRepository<AuthModel, AuthDto>, IAuthQueryRepository
    {
        public AuthQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}