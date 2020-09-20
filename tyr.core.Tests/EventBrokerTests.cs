using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tyr.Core.Events;
using tyr.Core.tests.EventTypes;

namespace tyr.Core.tests
{
    /// <summary>
    ///     EventBrokerTests contains all functional tests for EventBroker class
    /// </summary>
    [TestClass]
    public class EventBrokerTests
    {
        private readonly EventBroker _eventBroker = new EventBroker();

        public void GlobalTestHandler(object sender, EventName e)
        {
        }

        [TestMethod]
        public void SubscriptionAddedEvent()
        {
            var isRaised = false;

            _eventBroker.SubscriptionAdded += (sender, e) => isRaised = true;

            _eventBroker.Subscribe<EventName>(GlobalTestHandler);

            Assert.IsTrue(isRaised);
        }

        [TestMethod]
        public void SubscriptionAddedRemovedEvent()
        {
            var isRaisedSubscriptionAdded = false;
            var isRaisedSubscriptionRemoved = false;

            _eventBroker.SubscriptionAdded += (sender, e) => isRaisedSubscriptionAdded = true;

            _eventBroker.SubscriptionRemoved += (sender, e) => isRaisedSubscriptionRemoved = true;

            _eventBroker.Subscribe<EventName>(GlobalTestHandler);
            Assert.IsTrue(isRaisedSubscriptionAdded);

            _eventBroker.Unsubscribe<EventName>(GlobalTestHandler);
            Assert.IsTrue(isRaisedSubscriptionRemoved);
        }

        [TestMethod]
        public void FireEventWithNoSubscriptions()
        {
            var publisher = new SimplePubSubMock<TestEvent>(_eventBroker);
            publisher.FireEvent();
        }

        [TestMethod]
        public void SubscriptionsRemovedOnSubscriberDisposed()
        {
            var subscriber = new SimplePubSubMock<TestEvent>(_eventBroker);
            var publisher = new SimplePubSubMock<TestEvent>(_eventBroker);

            subscriber.SubscribeToEvent();

            publisher.FireEvent();
        }

        [TestMethod]
        public void FireSimpleEvent()
        {
            var subscriber = new SimplePubSubMock<TestEvent>(_eventBroker);
            var publisher = new SimplePubSubMock<TestEvent>(_eventBroker);

            subscriber.SubscribeToEvent();
            publisher.FireEvent();

            Assert.IsTrue(subscriber.EventFired);
        }


        [TestMethod]
        public void FireSimpleEventAndCheckEventArgs()
        {
            var subscriber = new SimplePubSubMock<GlobalEventInfo>(_eventBroker);
            var publisher = new SimplePubSubMock<GlobalEventInfo>(_eventBroker);

            object expected = "Some Vogon Poetry";

            subscriber.SubscribeToEvent();
            publisher.FireEvent(new GlobalEventInfo { Data = expected });

            Assert.AreSame(expected, subscriber.LastEventArgs.Data);
        }


        [TestMethod]
        public void FireSimpleEventAndCheckSender()
        {
            var subscriber = new SimplePubSubMock<TestEvent>(_eventBroker);
            var publisher = new SimplePubSubMock<TestEvent>(_eventBroker);

            subscriber.SubscribeToEvent();
            publisher.FireEvent();

            Assert.AreSame(publisher, subscriber.LastSender);
        }

        [TestMethod]
        public void FireEventWithMultipleSubscribers()
        {
            var subscriber1 = new SimplePubSubMock<TestEvent>(_eventBroker);
            var subscriber2 = new SimplePubSubMock<TestEvent>(_eventBroker);
            var subscriber3 = new SimplePubSubMock<TestEvent>(_eventBroker);

            var publisher = new SimplePubSubMock<TestEvent>(_eventBroker);

            subscriber1.SubscribeToEvent();
            subscriber2.SubscribeToEvent();
            subscriber3.SubscribeToEvent();

            publisher.FireEvent();

            Assert.IsTrue(subscriber1.EventFired);
            Assert.IsTrue(subscriber2.EventFired);
            Assert.IsTrue(subscriber3.EventFired);
        }


        [TestMethod]
        public void FireEventAfterUnsubscription()
        {
            var subscriber1 = new SimplePubSubMock<TestEvent>(_eventBroker);
            var subscriber2 = new SimplePubSubMock<TestEvent>(_eventBroker);
            var subscriber3 = new SimplePubSubMock<TestEvent>(_eventBroker);

            var publisher = new SimplePubSubMock<TestEvent>(_eventBroker);

            subscriber1.SubscribeToEvent();
            subscriber2.SubscribeToEvent();
            subscriber3.SubscribeToEvent();

            subscriber2.UnsubscribeFromEvent();

            publisher.FireEvent();

            Assert.IsTrue(subscriber1.EventFired);
            Assert.IsTrue(subscriber3.EventFired);

            Assert.IsFalse(subscriber2.EventFired);
        }

        [TestMethod]
        public void SubscribeUsingWorkingThread()
        {
            var subscriber = new SimplePubSubMock<TestEvent>(_eventBroker);
            var publisher = new SimplePubSubMock<TestEvent>(_eventBroker);

            void WaitCallback(object state)
            {
                subscriber.SubscribeToEvent();
            }

            ThreadPool.QueueUserWorkItem(WaitCallback);

            Thread.Sleep(100);

            publisher.FireEvent();

            Assert.IsTrue(subscriber.EventFired);
        }

        [TestMethod]
        public void SubscribeSingleSubscriberToMultipleEvents()
        {
            var subscriber = new SimplePubSubMock<GlobalEventInfo>(_eventBroker);
            var publisher = new SimplePubSubMock<GlobalEventInfo>(_eventBroker);

            subscriber.SubscribeToEvent();
            subscriber.SubscribeToEvent();
            subscriber.SubscribeToEvent();

            publisher.FireEvent(new GlobalEventInfo("3"));
            Assert.AreEqual("3", subscriber.LastEventArgs.Data.ToString());

            publisher.FireEvent(new GlobalEventInfo("2"));
            Assert.AreEqual("2", subscriber.LastEventArgs.Data.ToString());

            publisher.FireEvent(new GlobalEventInfo("1"));
            Assert.AreEqual("1", subscriber.LastEventArgs.Data.ToString());
        }
    }
}