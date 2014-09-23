using System;
using DomainEventsDemo.SharedKernel;

namespace DomainEventsDemo.Model.Events
{
    public class CustomerNameUpdatedEvent : DomainEvent
    {
        public override DateTime DateTimeEventOccurred { get; protected set; }
        public int CustomerId { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }

        public CustomerNameUpdatedEvent(int customerId, string oldName, string newName)
        {
            CustomerId = customerId;
            OldName = oldName;
            NewName = newName;
            DateTimeEventOccurred = DateTime.Now;
        }
    }
}