using Katsutoshi.Modules;
using Katsutoshi.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для DirectoryPage.xaml
    /// </summary>
    public partial class DirectoryPage : Page
    {
        private readonly DirectoryPageViewModel _viewModel;

        private readonly KatsuLogger logger;

        public DirectoryPage()
        {
            InitializeComponent();

            _viewModel = new DirectoryPageViewModel(Directory.GetCurrentDirectory());
            DataContext = _viewModel;

            logger = KatsuLogger.Instance;

            Loaded += DirectoryPage_Loaded;
        }

        private async void DirectoryPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _viewModel.LoadData();
                logger.Log(LogCode.Info, "Directory page loaded.");
            }
            catch (Exception ex)
            {
                logger.Log(LogCode.Error, ex.Message);
            }
        }
    }
}
