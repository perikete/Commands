using System;

namespace Commands.Bus
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
