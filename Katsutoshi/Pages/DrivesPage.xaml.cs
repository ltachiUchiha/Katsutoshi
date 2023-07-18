using Katsutoshi.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Katsutoshi.Pages
{
    /// <summary>
    /// Логика взаимодействия для DrivesPage.xaml
    /// </summary>
    public partial class DrivesPage : Page
    {
        private readonly DrivesViewModel _viewModel;

        public DrivesPage()
        {
            InitializeComponent();
            _viewModel = new DrivesViewModel();
            DataContext = _viewModel;
            Loaded += DrivesPage_Loaded;
        }

        // Drives page loaded
        private async void DrivesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadData();
        }
    }
}
