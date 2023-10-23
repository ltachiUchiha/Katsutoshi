using Katsutoshi.Modules;
using Katsutoshi.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Katsutoshi.Pages
{
    public partial class DrivesPage : Page
    {
        private readonly DrivesViewModel _viewModel;

        private readonly KatsuLogger logger;

        public DrivesPage()
        {
            InitializeComponent();
            _viewModel = new DrivesViewModel();
            DataContext = _viewModel;

            logger = KatsuLogger.Instance;

            Loaded += DrivesPage_Loaded;
        }


        public void DrivesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(DrivesListBox.SelectedItem != null)
            {
                _viewModel.OpenDriveCommand.Execute(DrivesListBox.SelectedIndex);
            }
        }

        // Drives page loaded
        private async void DrivesPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _viewModel.LoadData();
                logger.Log(LogCode.Info, "Drives page loaded.");
            }
            catch (Exception ex)
            {
                logger.Log(LogCode.Error, ex.Message);
            }
        }
    }
}
