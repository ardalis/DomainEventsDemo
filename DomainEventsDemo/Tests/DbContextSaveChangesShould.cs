using System.Linq;
using DomainEventsDemo.Infrastructure.Data;
using DomainEventsDemo.Model;
using DomainEventsDemo.Model.Events;
using DomainEventsDemo.SharedKernel;
using NUnit.Framework;
using StructureMap;
using StructureMap.Graph;

namespace DomainEventsDemo.Tests
{
    public class TestCustomerEventHandler : IHandle<CustomerNameUpdatedEvent>
    {
        public void Handle(CustomerNameUpdatedEvent args)
        {
            DbContextSaveChangesShould.HandledEvent = args;
        }
    }

    [TestFixture]
    public class DbContextSaveChangesShould
    {
        private readonly string _testCustomerName = "ardalis";
        public static CustomerNameUpdatedEvent HandledEvent = null;

        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            _container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.ConnectImplementationsToTypesClosing(typeof(IHandle<>));
                });
            });
            HandledEvent = null;
        }

        [Test]
        public void DispatchEvents()
        {
            var customer = new Customer("Steve");
            customer.UpdateName(_testCustomerName);
            var db = _container.GetInstance<DbContext>();
            db.Customers.Add(customer);
            Assert.IsNull(HandledEvent);

            db.SaveChanges(); // should call TestCustomerEventHandler

            Assert.IsNotNull(HandledEvent);
            Assert.AreEqual(_testCustomerName, HandledEvent.NewName);
        }
    }
}