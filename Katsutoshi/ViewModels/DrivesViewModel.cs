using Katsutoshi.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Katsutoshi.ViewModels
{
    public class DrivesViewModel : INotifyPropertyChanged
    {
        private DrivesModel drivesModel;
        public ObservableCollection<DriveInfo> _drives;

        public ObservableCollection<DriveInfo> drives { 
            get => _drives;
            set
            {
                _drives = value;
                OnPropertyChanged();
            }
        }

        // Constructor
        public DrivesViewModel()
        {
            drivesModel = new DrivesModel();
        }

        // Load data from drives model
        public async Task LoadData()
        {
            try
            {
                drives = await drivesModel.GetAllDrives();
            }
            catch (Exception)
            {

            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
