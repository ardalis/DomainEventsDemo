using System;
using DomainEventsDemo.SharedKernel;

namespace DomainEventsDemo.Model.Events
{
    public class CounterIncrementedEvent : DomainEvent
    {
        public override DateTime DateTimeEventOccurred { get; protected set; }
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