using TOFI.TransferObjects.User.Commands;

namespace DAL.Repositories.User
{
    public interface IUserCommandRepository : IRepository,
        ICommandRepository<RegisterCommand>
    {
    }
}