using AssoSw.Lesson7.WpfConsumingAPI.ViewModels;
using System.Windows;

namespace AssoSw.Lesson7.WpfConsumingAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginViewModel viewModel = new LoginViewModel();
            DataContext = viewModel;
        }
    }
}
