using System.Collections.Generic;
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

        private IList<Customer> _customers = new List<Customer>();

        public IList<Customer> Customers
        {
            get { return _customers; }
        }

        // dispatches events, then saves
        // could be done in a transaction, or events could fire only after
        // successful save
        public void SaveChanges()
        {
            // save changes - for demo purposes we're skipping this part

            // dispatch events on any entities that have changes detected
            var changedCustomers = _customers;
            foreach (var customer in changedCustomers)
            {
                foreach (var domainEvent in customer.Events)
                {
                    _domainEventDispatcher.Dispatch((dynamic)domainEvent);
                }
            }

            
        }
    }
}