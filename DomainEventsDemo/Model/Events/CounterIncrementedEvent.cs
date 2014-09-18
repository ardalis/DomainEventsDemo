using System;
using DomainEventsDemo.SharedKernel;

namespace DomainEventsDemo.Model.Events
{
    public class CounterIncrementedEvent : IDomainEvent
    {
        public DateTime DateTimeEventOccurred { get; private set; }
        public string CounterName { get; private set; }
        public int CounterCount { get; private set; }
        
        public CounterIncrementedEvent(Counter counter, DateTime timeOfEvent)
        {
            DateTimeEventOccurred = timeOfEvent;
            CounterName = counter.Name;
            CounterCount = counter.Count;
        }
    }
}