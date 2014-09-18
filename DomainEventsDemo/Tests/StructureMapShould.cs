using System;
using DomainEventsDemo.Model;
using DomainEventsDemo.Model.Events;
using DomainEventsDemo.SharedKernel;
using NUnit.Framework;
using StructureMap;
using StructureMap.Graph;

namespace DomainEventsDemo.Tests
{
    public class TestHandler : IHandle<CounterIncrementedEvent>
    {
        public CounterIncrementedEvent HandledEvent { get; private set; }
        public void Handle(CounterIncrementedEvent args)
        {
            this.HandledEvent = args;
            StructureMapShould.TestHandlerHandledEvent = args;
        }
    }

    [TestFixture]
    public class StructureMapShould
    {
        private IContainer _container;
        public static CounterIncrementedEvent TestHandlerHandledEvent = null;

        [SetUp]
        public void SetUp()
        {
            _container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
                });
            });

        }

        [Test]
        public void AutomaticallyRegisterTestHandler()
        {
            var handler = _container.GetInstance<IHandle<CounterIncrementedEvent>>();
            Assert.IsInstanceOf<TestHandler>(handler);
        }

        [Test]
        public void CallHandleOnTestHandlerWhenRaiseIsCalled()
        {
            var testCounterName = "testCounterName" + Guid.NewGuid();
            DomainEvents.Container = _container;
            DomainEvents.ClearCallbacks();
            var counter = new Counter(testCounterName);
            counter.Increment(); // should call TestHandler

            Assert.AreEqual(testCounterName, TestHandlerHandledEvent.CounterName);
        }
    }
}