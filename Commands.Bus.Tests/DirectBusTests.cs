using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commands.Bus.Direct;
using Commands.Bus.Persistence;
using Commands.Bus.MemoryPersistence;

namespace Commands.Bus.Tests
{
    [TestClass]
    public class DirectBusTests
    {
        private static readonly ICommandRouter _testCommandRouter = new CommandRouter();
        private static readonly ICommandRepository _commandRepository = new MemoryCommandRepository();
        
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _testCommandRouter.RegisterCommandHandler<TestCommand>(new TestCommandHandler(_commandRepository));
        }

        [TestMethod]
        public void Can_Publish_A_Message()
        {
            var bus = new DirectBus(_testCommandRouter);
            var testEntity = new TestEntity();
            var testCommand = new TestCommand(testEntity, "Peter", "Frampton", 23);
                
            bus.Publish(testCommand);

            Assert.AreEqual(testCommand.Name, testEntity.Name);
            Assert.AreEqual(testCommand.Age, testEntity.Age);
            Assert.AreEqual(testCommand.Lastname, testEntity.Lastname);
            Assert.IsNotNull(_commandRepository.Get(testCommand.Id));
        }

        [TestMethod]
        public void Can_Publish_A_Message_To_Multiple_Handlers()
        {
            var router = new CommandRouter();
            router.RegisterCommandHandler<TestCommand>(new TestCommandHandler(_commandRepository));
            router.RegisterCommandHandler<TestCommand>(new TestCommandHandler1(_commandRepository));
            var bus = new DirectBus(router);
            var testEntity = new TestEntity();
            var testCommand = new TestCommand(testEntity, "Roberto", "Sanchez", 10);

            bus.Publish(testCommand);

            Assert.AreEqual(testCommand.Name.ToUpperInvariant(), testEntity.Name);
            Assert.AreEqual(testCommand.Lastname.ToUpperInvariant(), testEntity.Lastname);
            Assert.AreEqual(20, testEntity.Age);
            Assert.IsNotNull(_commandRepository.Get(testCommand.Id));
        }

        private ICommandRepository GetRepository()
        {
            return new MemoryCommandRepository();
        }
    }
}
