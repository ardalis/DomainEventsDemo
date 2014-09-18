using System;
using DomainEventsDemo.Model.Events;

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

        public void Increment()
        {
            Count++;
            SharedKernel.DomainEvents.Raise(new CounterIncrementedEvent(this, DateTime.Now));
        }
    }
}