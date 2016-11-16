using System.Linq;
using AutoMapper;
using DAL.Contexts;
using DAL.Models.Auth;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Auth.DataObjects;
using TOFI.TransferObjects.Auth.Queries;

namespace DAL.Repositories.Auth
{
    public class AuthQueryRepository : ModelQueryRepository<AuthModel, AuthDto>, IAuthQueryRepository
    {
        public AuthQueryRepository(TofiContext context) : base(context)
        {
        }


        public LoginDto Handle(LoginQuery query)
        {
            AuthModel resModel = null;
            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                resModel = ModelsDao.FirstOrDefault(user => user.Email == query.Email);
            }
            if (!string.IsNullOrWhiteSpace(query.Username))
            {
                resModel = ModelsDao.FirstOrDefault(user => user.Username == query.Username);
            }
            return resModel == null ? null : Mapper.Map<LoginDto>(resModel);
        }
    }
}