using DAL.Contexts;
using DAL.Models.Auth;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;

namespace DAL.Repositories.Auth
{
    public class AuthCommandRepository : ModelCommandRepository<AuthModel, AuthDto>, IAuthCommandRepository
    {
        public AuthCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}