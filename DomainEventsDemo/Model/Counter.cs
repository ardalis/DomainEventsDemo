using System;
using DomainEventsDemo.Model.Events;
using DomainEventsDemo.SharedKernel;

namespace DomainEventsDemo.Model
{
    public class Counter
    {
        public string Name { get; private set; }
        public int Count { get; private set; }

        public Counter(string name)
        {
            Name = name;
        }

        // Raise events directly from objects
        public void Increment()
        {
            Count++;
            DomainEvents.Raise(new CounterIncrementedEvent(this, DateTime.Now));
        }
    }
}