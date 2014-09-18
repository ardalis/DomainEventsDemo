using DomainEventsDemo.Model;
using DomainEventsDemo.Model.Events;
using DomainEventsDemo.SharedKernel;
using NUnit.Framework;

namespace DomainEventsDemo.Tests
{
    [TestFixture]
    public class CounterIncrementShould
    {
        private readonly string _testCounterName = "testcounter";
        [Test]
        public void IncreaseCounterBy1()
        {
            var counter = new Counter(_testCounterName);

            int initialCount = counter.Count;
            counter.Increment();
            Assert.AreEqual(initialCount+1, counter.Count);
        }

        [Test]
        public void RaiseCounterIncrementedEvent()
        {
            string eventRaisedByCounter = "";
            int currentCount = 0;
            var counter = new Counter(_testCounterName);
            DomainEvents.ClearCallbacks();
            DomainEvents.Register<CounterIncrementedEvent>(c =>
            {
                eventRaisedByCounter = c.CounterName;
                currentCount = c.CounterCount;
            });

            counter.Increment();
            Assert.AreEqual(eventRaisedByCounter, _testCounterName);
            Assert.AreEqual(1, currentCount);
        }
    }
}