using AssoSw.Lesson7.WpfConsumingAPI.ViewModels;
using System.Windows;

namespace AssoSw.Lesson7.WpfConsumingAPI
{
    /// <summary>
    /// Interaction logic for CustomerListWindow.xaml
    /// </summary>
    public partial class CustomerListWindow : Window
    {
        public CustomerListWindow()
        {
            InitializeComponent();
            CustomerListViewModel viewModel = new CustomerListViewModel();
            DataContext = viewModel;
        }
    }
}
