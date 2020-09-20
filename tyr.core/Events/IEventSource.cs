namespace tyr.Core.Events
{
    public interface IEventSource
    {
        EventBroker Broker { get; }
    }
}