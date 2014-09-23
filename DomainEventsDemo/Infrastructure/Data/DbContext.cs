using System.Collections.Generic;
using System.Linq;
using DomainEventsDemo.Model;
using DomainEventsDemo.SharedKernel;

namespace DomainEventsDemo.Infrastructure.Data
{
    public class DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public DbContext(IDomainEventDispatcher domainEventDispatcher)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        private static IDictionary<int, Customer> _customers = new Dictionary<int, Customer>();


        public static IDictionary<int, Customer> Customers
        {
            get { return _customers; }
        }

        public void SaveChanges()
        {
            // dispatch events on any entities that have changes detected
            var changedCustomers = _customers;
            foreach (var customer in changedCustomers.Values)
            {
                foreach (var domainEvent in customer.Events)
                {
                    _domainEventDispatcher.Dispatch((dynamic)domainEvent);
                }
            }

            // save changes - for demo purposes we're skipping this part
        }
    }
}