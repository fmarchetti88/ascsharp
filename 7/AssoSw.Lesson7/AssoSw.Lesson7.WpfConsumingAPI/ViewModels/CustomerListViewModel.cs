using AssoSw.Lesson7.WpfConsumingAPI.Models;
using AssoSw.Lesson7.WpfConsumingAPI.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AssoSw.Lesson7.WpfConsumingAPI.ViewModels
{
    public class CustomerListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> _customers;

        public CustomerListViewModel()
        {
            CloseCommand = new DelegateCommand(OnClose);
            APIRequestor.GetCustomersAsync().ContinueWith(task =>
            {
                Customers = new ObservableCollection<Customer>(task.Result);
            });
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

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; OnPropertyChanged(nameof(Customers)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
