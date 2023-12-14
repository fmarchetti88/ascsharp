using AssoSw.Lesson6.Wpf.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace AssoSw.Lesson6.Wpf.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            SaveCommand = new DelegateCommand(OnSave);
            ViewCustomersCommand = new DelegateCommand(OnViewCustomers);
            SetPropertyCommand = new DelegateCommand(OnSetProperty);
        }

        public Customer Customer
        {
            get; set;
        }

        public ICommand SaveCommand
        {
            get;
            internal set;
        }

        private void OnSave(object @params)
        {
            if (String.IsNullOrEmpty(Customer.Name) || String.IsNullOrEmpty(Customer.Surname))
            {
                MessageBox.Show("Nome o Cognome sono obbligatori!", "Errore");
                return;
            }

            MyDbRepository.AddCustomer(Customer);
            MessageBox.Show("Cliente salvato con successo!");
        }

        private void OnViewCustomers(object @params)
        {
            CustomerListWindow customerListWindow = new CustomerListWindow();
            customerListWindow.Show();
        }

        private void OnSetProperty(object @params)
        {
            if (Customer != null)
            {
                Customer.Name = "Ciao, ti ho cambiato la proprietà!";
            }
        }

        public ICommand ViewCustomersCommand
        {
            get;
            internal set;
        }

        public ICommand SetPropertyCommand
        {
            get;
            internal set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
