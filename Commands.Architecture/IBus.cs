namespace Commands.Bus
{
    public interface IBus
    {
        void Publish(object command);
    }
}
