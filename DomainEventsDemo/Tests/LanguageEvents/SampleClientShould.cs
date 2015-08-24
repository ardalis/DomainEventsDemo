using DomainEventsDemo.LanguageEvents;
using NUnit.Framework;

namespace DomainEventsDemo.Tests.LanguageEvents
{
    [TestFixture]
    public class SampleClientShould
    {
        private SampleClient _sampleClient;
        private Customer _customer;
        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();
            _sampleClient = new SampleClient(_customer);
        }
        [Test]
        public void LogToOutputWhenNameUpdated()
        {
            _sampleClient.UpdateCustomer("Steve");
            Assert.AreEqual("Customer name changed", _sampleClient.Output());
        }

    }
}