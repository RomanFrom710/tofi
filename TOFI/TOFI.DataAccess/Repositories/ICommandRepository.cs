using TOFI.TransferObjects;

namespace DAL.Repositories
{
    public interface ICommandRepository<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}