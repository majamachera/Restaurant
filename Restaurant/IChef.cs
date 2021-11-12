namespace Restaurant
{
    public interface IChef
    {
        void Attach(IWaiter observer);

        void Detach(IWaiter observer);

        void Notify();
    }
}