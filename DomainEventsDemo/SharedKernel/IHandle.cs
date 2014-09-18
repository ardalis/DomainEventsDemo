namespace DomainEventsDemo.SharedKernel
{
    public interface IHandle<T> where T : DomainEvent
    {
        void Handle(T args);
    }
}
