using Katsutoshi.Models;
using Katsutoshi.Modules;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Katsutoshi.ViewModels
{
    public class DrivesViewModel : INotifyPropertyChanged
    {
        private DrivesModel drivesModel;    
        private readonly KatsuLogger logger;

        // Bindable properties
        public ObservableCollection<DriveInfo> _drives;

        // Implementation
        public ObservableCollection<DriveInfo> drives { 
            get => _drives;
            set
            {
                _drives = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenDriveCommand { get; set; }

        public DrivesViewModel()
        {
            drivesModel = new DrivesModel();
            logger = KatsuLogger.Instance;

            OpenDriveCommand = new RelayCommand(param =>
            {
                logger.Log(LogCode.Warn, $"Element {param} selected - Open not implemented.");
            });
        }

        // Load data from drives model
        public async Task LoadData()
        {
            try
            {
                drives = await drivesModel.GetAllDrives();
            }
            catch (Exception ex)
            {
                logger.Log(LogCode.Error, ex.Message);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
