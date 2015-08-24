using System;
using System.Text;
using DomainEventsDemo.SharedKernel;
using DomainEventsDemo.SharedKernel.StaticApproach;

namespace DomainEventsDemo.UdiDomainEvents
{
    public class Customer
    {
        public string Name { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
            DomainEvents.Raise(new CustomerNameUpdatedEvent(this));
        }
    }

    public class CustomerNameUpdatedEvent : DomainEvent
    {
        public override DateTime DateTimeEventOccurred { get; protected set; }
        public Customer Customer { get; }

        public CustomerNameUpdatedEvent(Customer customer)
        {
            Customer = customer;
            this.DateTimeEventOccurred = DateTime.Now;
        }
    }

    public class SampleClient
    {
        private readonly Customer _customer;
        private StringBuilder _output = new StringBuilder();

        public SampleClient(Customer customer)
        {
            _customer = customer;
            DomainEvents.Register< CustomerNameUpdatedEvent>(CustomerOnNameChanged);
        }

        public void UpdateCustomer(string newname)
        {
            _customer.UpdateName(newname);
        }

        public string Output()
        {
            return _output.ToString();
        }

        public void CustomerOnNameChanged(CustomerNameUpdatedEvent customerNameUpdatedEvent)
        {
            _output.Append("Customer name changed");
        }
    }
}
