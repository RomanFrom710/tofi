using System.Linq;
using DAL.Contexts;
using DAL.Models.User;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace DAL.Repositories.User
{
    public abstract class UserQueryRepository<TUser> : ModelRepository<TUser>, IUserQueryRepository
        where TUser : UserModel
    {
        protected UserQueryRepository(TofiContext context) : base(context)
        {
        }


        public IQueryable<LoginDto> Handle(LoginQuery query)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<UserDto> Handle(UserQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}