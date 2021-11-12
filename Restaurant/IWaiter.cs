namespace Restaurant
{
    public interface IWaiter
    {
        void Update(IChef subject);

        void OnUpdate(object sender, ReadyEventArg eventArgs);
    }
}