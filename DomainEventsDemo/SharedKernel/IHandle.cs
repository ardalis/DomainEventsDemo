namespace DomainEventsDemo.SharedKernel
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
