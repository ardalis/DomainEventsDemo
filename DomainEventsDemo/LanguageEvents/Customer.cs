using System;

namespace DomainEventsDemo.LanguageEvents
{
    public delegate void CustomerNameChangedEventHandler(object sender, EventArgs e);

    public class Customer
    {
        public event CustomerNameChangedEventHandler NameChanged;

        public string Name { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
            NameChanged(this, EventArgs.Empty);
        }
    }
}
