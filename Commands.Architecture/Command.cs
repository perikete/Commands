using System;

namespace Commands.Bus
{
    public abstract class Command : ICommand
    {
        public Guid Id { get; private set; }

        public Command()
        {
            this.Id = Guid.NewGuid();
        }
        
    }
}
