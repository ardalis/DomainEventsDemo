using System;

namespace DomainEventsDemo.SharedKernel
{
    public abstract class DomainEvent
    {
        public abstract DateTime DateTimeEventOccurred { get; protected set; }
    }
}