using Commands.Bus;

namespace Commands.Persistence.MemoryPersistence
{
    public class MemoryCommandRepository<TCommand> : ICommandRepository<TCommand> where TCommand : ICommand
    {
    }
}
