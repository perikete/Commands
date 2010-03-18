using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commands.Bus.Tests
{
    public class TestCommand : Command
    {
        public TestEntity Entity { get; private set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
      
        public TestCommand(TestEntity entity, string name, string lastname, int age)
        {
            this.Entity = entity;
            this.Name = name;
            this.Age = age;
            this.Lastname = lastname;
        }
    }
}
