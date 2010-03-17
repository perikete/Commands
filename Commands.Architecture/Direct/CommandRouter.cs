using System.Collections.Generic;
using System;

namespace Commands.Bus.Direct
{
    public class CommandRouter : ICommandRouter
    {
        private readonly IDictionary<Type, object> _commandHandlers;

        public CommandRouter()
        {
            _commandHandlers = new Dictionary<Type, object>();
        }
        
        public void RegisterCommandHandler<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : class, ICommand
        {
            var routingKey = typeof(TCommand);
            _commandHandlers.Add(routingKey, commandHandler);
        }

        public void Route(object command)
        {
            object handler;
            if (_commandHandlers.TryGetValue(command.GetType(), out handler))
            {
                // improve?
                handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { command });   
            }

        }
    }
}
