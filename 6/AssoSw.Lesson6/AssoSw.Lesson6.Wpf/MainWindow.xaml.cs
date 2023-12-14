using AssoSw.Lesson6.Wpf.ViewModels;
using System.Windows;

namespace AssoSw.Lesson6.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.Customer = new Models.Customer();
            DataContext = viewModel;
        }
    }
}
