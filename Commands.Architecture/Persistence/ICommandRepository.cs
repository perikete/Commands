using System;

namespace Commands.Bus.Persistence
{
    public interface ICommandRepository
    {
        ICommand Get(Guid id);
        void Save(ICommand command);
    }
}
