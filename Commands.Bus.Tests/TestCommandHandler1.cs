using Commands.Bus.Persistence;

namespace Commands.Bus.Tests
{
    public class TestCommandHandler1 : CommandHandler<TestCommand>
    {
        public TestCommandHandler1(ICommandRepository commandRepository)
            : base(commandRepository)
        {

        }

        protected override void HandleCore(TestCommand command)
        {
            command.Entity.Age += 10;
            command.Entity.Lastname = command.Entity.Lastname.ToUpperInvariant();
            command.Entity.Name = command.Entity.Name.ToUpperInvariant();
        }
    }
}
