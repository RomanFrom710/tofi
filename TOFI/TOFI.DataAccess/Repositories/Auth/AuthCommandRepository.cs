using DAL.Contexts;
using DAL.Models.Auth;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;

namespace DAL.Repositories.Auth
{
    public abstract class AuthCommandRepository<TAuth, TAuthDto> : ModelCommandRepository<TAuth, TAuthDto>, IAuthCommandRepository<TAuthDto>
        where TAuth : AuthModel, new() where TAuthDto : AuthDto
    {
        protected AuthCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}