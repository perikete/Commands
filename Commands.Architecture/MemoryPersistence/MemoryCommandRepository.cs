using Commands.Bus;
using Commands.Bus.Persistence;
using System;
using System.Collections.Generic;

namespace Commands.Bus.MemoryPersistence
{
    public class MemoryCommandRepository : ICommandRepository
    {
        private IDictionary<Guid, ICommand> _commands;

        public MemoryCommandRepository()
        {
            _commands = new Dictionary<Guid, ICommand>();
        }
        
        public ICommand Get(Guid id)
        {
            return _commands[id];
        }

        public void Save(ICommand command)
        {
            _commands.Add(command.Id, command);
        }
    }
}
