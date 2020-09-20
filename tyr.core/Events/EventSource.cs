namespace tyr.Core.Events
{
    public abstract class EventSource : IEventSource
    {
        public virtual EventBroker Broker { get; protected set; }
    }
}