namespace DomainEventsDemo.SharedKernel
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(DomainEvent domainEvent);
    }
}