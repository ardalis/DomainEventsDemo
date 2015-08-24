using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class SampleClient
    {
        private readonly Customer _customer;
        private StringBuilder _output = new StringBuilder();

        public SampleClient(Customer customer)
        {
            _customer = customer;
            _customer.NameChanged += CustomerOnNameChanged;
        }

        public void UpdateCustomer(string newname)
        {
            _customer.UpdateName(newname);
        }

        public string Output()
        {
            return _output.ToString();
        }

        private void CustomerOnNameChanged(object sender, EventArgs eventArgs)
        {
            _output.Append("Customer name changed");
        }

        public void Detach()
        {
            _customer.NameChanged -= CustomerOnNameChanged;
        }
    }
}
