using DAL.Contexts;
using DAL.Models.User;
using TOFI.TransferObjects.User.Commands;

namespace DAL.Repositories.User
{
    public abstract class UserCommandRepository<TUser> : ModelRepository<TUser>, IUserCommandRepository
        where TUser : UserModel
    {
        protected UserCommandRepository(TofiContext context) : base(context)
        {
        }


        public void Execute(RegisterCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}