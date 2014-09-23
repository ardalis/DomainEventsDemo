using System.Collections.Generic;

namespace DomainEventsDemo.SharedKernel
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public ICollection<DomainEvent> Events { get; private set; }

        protected EntityBase()
        {
            this.Events = new List<DomainEvent>();
        }
    }
}