using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands.Bus.Tests
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public void Handle(TestCommand command)
        {

            command.Entity.Age = command.Age;
            command.Entity.Lastname = command.Lastname;
            command.Entity.Name = command.Name;
        }
    }
}
