namespace Commands.Bus.Direct
{
    public class DirectBus : IBus
    {
        protected ICommandRouter CommandRouter { get; set; }

        public DirectBus(ICommandRouter commandRouter)
        {
            this.CommandRouter = commandRouter;
        }
        
        public void Publish(object command)
        {
            this.CommandRouter.Route(command);
        }
    }
}
