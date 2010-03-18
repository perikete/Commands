using System.Collections.Generic;
using System;

namespace Commands.Bus.Direct
{
    public class CommandRouter : ICommandRouter
    {
        private readonly IDictionary<Type, List<object>> _commandHandlers;

        public CommandRouter()
        {
            _commandHandlers = new Dictionary<Type, List<object>>();
        }
        
        public void RegisterCommandHandler<TCommand>(ICommandHandler<TCommand> commandHandler) where TCommand : class, ICommand
        {
            var routingKey = typeof(TCommand);
            List<object> handlers;

            if (_commandHandlers.TryGetValue(routingKey, out handlers))
            {
                handlers.Add(commandHandler);
            }
            else
            { 
                handlers = new List<object> { commandHandler };
                _commandHandlers.Add(routingKey, handlers);
            }
        }

        public void Route(object command)
        {
            List<object> handlers;
            if (_commandHandlers.TryGetValue(command.GetType(), out handlers))
            {
                foreach (var handler in handlers)
                {
                    // improve?
                    handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { command });
                }
            }
        }
    }
}
