using AssoSw.Lesson6.Wpf.ViewModels;
using System.Windows;

namespace AssoSw.Lesson6.Wpf
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
