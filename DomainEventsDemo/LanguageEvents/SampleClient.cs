using System;
using System.Text;

namespace DomainEventsDemo.LanguageEvents
{
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