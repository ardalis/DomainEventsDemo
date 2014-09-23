using System.Linq;
using DomainEventsDemo.Model;
using DomainEventsDemo.Model.Events;
using DomainEventsDemo.SharedKernel;
using NUnit.Framework;

namespace DomainEventsDemo.Tests
{
    [TestFixture]
    public class CustomerUpdateNameShould
    {
        private readonly string _testCustomerName = "ardalis";

        [Test]
        public void ChangeCustomerName()
        {
            var customer = new Customer("Steve");
            customer.UpdateName(_testCustomerName);
            Assert.AreEqual(_testCustomerName, customer.Name);
        }

        [Test]
        public void RecordCustomerNameUpdatedEvent()
        {
            var customer = new Customer("Steve");
            customer.UpdateName(_testCustomerName);

            Assert.AreEqual(1, customer.Events.Count);
            var updatedEvent = customer.Events.FirstOrDefault() as CustomerNameUpdatedEvent;
            Assert.AreEqual("Steve", updatedEvent.OldName);
            Assert.AreEqual(_testCustomerName, updatedEvent.NewName);
        }
    }
}