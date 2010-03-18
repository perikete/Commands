using Commands.Bus.Persistence;

namespace Commands.Bus
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected ICommandRepository CommandRepository { get; set; }
        
        protected CommandHandler(ICommandRepository commandRepository)
        {
            this.CommandRepository = commandRepository;
        }
        
        public void Handle(TCommand command)
        {
            this.HandleCore(command);
            this.CommandRepository.Save(command);
        }

        protected abstract void HandleCore(TCommand command);
    }
}
