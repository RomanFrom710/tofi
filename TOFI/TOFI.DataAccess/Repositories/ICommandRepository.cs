using TOFI.TransferObjects;

namespace DAL.Repositories
{
    public interface ICommandRepository<TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}