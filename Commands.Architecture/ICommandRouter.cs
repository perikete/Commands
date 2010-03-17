using System;

namespace Commands.Bus
{
    public interface ICommandRouter
    {
        void RegisterCommandHandler<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : class, ICommand;
        void Route(object command);
    }
}
