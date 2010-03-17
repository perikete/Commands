using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Commands.Bus.Direct;

namespace Commands.Bus.Tests
{
    [TestClass]
    public class DirectBusTests
    {
        private static readonly ICommandRouter _testCommandRouter = new CommandRouter();

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _testCommandRouter.RegisterCommandHandler<TestCommand>(new TestCommandHandler());
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
        }
    }
}
