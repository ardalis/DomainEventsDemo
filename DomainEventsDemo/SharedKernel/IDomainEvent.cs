using System;

namespace DomainEventsDemo.SharedKernel
{
    public interface IDomainEvent
    {
        DateTime DateTimeEventOccurred { get; }
    }
}