using tyr.Core.Events;
using tyr.Core.tests.EventTypes;

namespace tyr.Core.tests
{
    public class SimplePubSubMock<T> where T : GlobalEventInfo, new()
    {
        private readonly EventBroker _broker;
        public int Counter;
        public bool EventFired;
        public T LastEventArgs;
        public object LastSender;

        public SimplePubSubMock(EventBroker broker)
        {
            _broker = broker;
        }

        public void Event(object sender, T e)
        {
            EventFired = true;
            Counter++;
            LastEventArgs = e;
            LastSender = sender;
        }

        public void SubscribeToEvent()
        {
            _broker.Subscribe<T>(Event);
        }

        public void UnsubscribeFromEvent()
        {
            _broker.Unsubscribe<T>(Event);
        }

        public void FireEvent()
        {
            _broker.Publish(this, new T());
        }

        public void FireEvent(T e)
        {
            _broker.Publish(this, e);
        }
    }
}