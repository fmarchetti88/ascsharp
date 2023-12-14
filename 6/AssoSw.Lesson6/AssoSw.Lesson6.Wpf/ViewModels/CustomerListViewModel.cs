using AssoSw.Lesson6.Wpf.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace AssoSw.Lesson6.Wpf.ViewModels
{
    public class CustomerListViewModel
    {
        public CustomerListViewModel()
        {
            CloseCommand = new DelegateCommand(OnClose);
            Customers = MyDbRepository.GetCustomers();
        }

        public ICommand CloseCommand
        {
            get; private set;
        }

        private void OnClose(object @params)
        {
            if (@params is CustomerListWindow customerListWindow && customerListWindow != null)
            {
                customerListWindow.Close();
            }
        }

        public List<Customer> Customers
        {
            get; private set;
        }
    }
}
