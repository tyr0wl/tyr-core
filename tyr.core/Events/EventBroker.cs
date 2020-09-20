using System;
using System.Collections.Generic;

namespace tyr.Core.Events
{
    public class EventBroker
    {
        public delegate void EventDelegate<in T>(object sender, T eventInfo) where T : EventInfoBase;

        private Dictionary<Type, List<Delegate>> _subscriptions;

        /// <summary>
        ///     Gets or sets the internal subscriptions dictionary.
        /// </summary>
        /// <value>The subscriptions.</value>
        private Dictionary<Type, List<Delegate>> Subscriptions => _subscriptions ?? (_subscriptions = new Dictionary<Type, List<Delegate>>());

        public event EventHandler SubscriptionAdded = delegate { };
        public event EventHandler SubscriptionRemoved = delegate { };

        private void OnSubscriptionAdded(EventArgs e)
        {
            SubscriptionAdded(this, e);
        }

        private void OnSubscriptionRemoved(EventArgs e)
        {
            SubscriptionRemoved(this, e);
        }

        public void Subscribe<T>(EventDelegate<T> handler) where T : EventInfoBase
        {
            List<Delegate> delegates;
            var typeId = typeof(T);

            if (Subscriptions.ContainsKey(typeId))
            {
                delegates = _subscriptions[typeId];
            }
            else
            {
                delegates = new List<Delegate>();
                Subscriptions.Add(typeId, delegates);
            }

            delegates.Add(handler);
            OnSubscriptionAdded(new EventArgs());
        }

        /// <summary>
        ///     Unsubscribe method from event notifications
        /// </summary>
        /// <param name="handler">The method.</param>
        public void Unsubscribe<T>(EventDelegate<T> handler) where T : EventInfoBase
        {
            var typeId = typeof(T);
            if (Subscriptions.ContainsKey(typeId))
            {
                if (Subscriptions[typeId].Contains(handler))
                {
                    Subscriptions[typeId].Remove(handler);
                    OnSubscriptionRemoved(new EventArgs());
                }

                if (Subscriptions[typeId].Count == 0)
                {
                    Subscriptions.Remove(typeId);
                }
            }
        }

        /// <summary>
        ///     Fire the specified event by and pass parameters.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <param name="sender"></param>
        public void Publish<T>(object sender, T args) where T : EventInfoBase
        {
            List<Delegate> handlerPlain;
            if (Subscriptions.TryGetValue(typeof(T), out handlerPlain))
            {
                foreach (var @delegate in handlerPlain)
                {
                    var handler = (EventDelegate<T>) @delegate;
                    handler(sender, args);
                }
            }
        }
    }
}