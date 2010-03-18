using Commands.Bus.Persistence;

namespace Commands.Bus.Tests
{
    public class TestCommandHandler : CommandHandler<TestCommand>
    {
        public TestCommandHandler(ICommandRepository commandRepository)
            : base(commandRepository)
        {

        }
        
        protected override void HandleCore(TestCommand command)
        {
            command.Entity.Age = command.Age;
            command.Entity.Lastname = command.Lastname;
            command.Entity.Name = command.Name;
        }
    }
}
