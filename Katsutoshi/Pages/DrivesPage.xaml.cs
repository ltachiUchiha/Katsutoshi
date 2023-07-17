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
        public DrivesPage()
        {
            InitializeComponent();

            Loaded += DrivesPage_Loaded;
        }

        private void DrivesPage_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new DrivesViewModel();
        }
    }
}
