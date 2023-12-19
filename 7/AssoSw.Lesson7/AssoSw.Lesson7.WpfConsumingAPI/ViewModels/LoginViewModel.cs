using AssoSw.Lesson7.WpfConsumingAPI.Models;
using AssoSw.Lesson7.WpfConsumingAPI.Service;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AssoSw.Lesson7.WpfConsumingAPI.ViewModels
{
    // LoginViewModel.cs
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private string _token;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Token
        {
            get { return _token; }
            set { _token = value; OnPropertyChanged(nameof(Token)); }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            // Inizializza il comando di login
            LoginCommand = new DelegateCommand(OnLogin);
        }

        private async void OnLogin(object @params)
        {
            var result = await APIRequestor.LoginAsync(new AuthRequestDTO
            {
                Email = this.Email,
                Password = this.Password
            });

            if (!result)
            {
                MessageBox.Show("Login fallito");
            }
            else
            {
                CustomerListWindow customerListWindow = new CustomerListWindow();
                customerListWindow.Show();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
