using DAL.Contexts;
using DAL.Models.User;
using TOFI.TransferObjects.User.Commands;

namespace DAL.Repositories.User
{
    public abstract class UserCommandRepository<TUser> : ModelRepository<TUser>, IUserCommandRepository
        where TUser : UserModel, new()
    {
        protected UserCommandRepository(TofiContext context) : base(context)
        {
        }


        public void Execute(RegisterCommand command)
        {
            var user = new TUser
            {
                Email = command.Email,
                Username = command.Username,
                PasswordHash = command.PasswordHash,
                FirstName = command.FirstName,
                LastName = command.LastName
            };
            ModelsDao.Add(user);
        }
    }
}