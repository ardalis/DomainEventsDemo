using DomainEventsDemo.Model.Events;
using DomainEventsDemo.SharedKernel;

namespace DomainEventsDemo.Model
{
    public class Customer : EntityBase
    {
        public string Name { get; private set; }

        protected Customer()
        {
        }

        public Customer(string name)
        {
            Name = name;
        }

        // add events to collection; dispatched during save
        public void UpdateName(string newName)
        {
            Events.Add(new CustomerNameUpdatedEvent(Id, Name, newName));
            Name = newName;
        }
    }
}
