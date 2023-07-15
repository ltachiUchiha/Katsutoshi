using Katsutoshi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
