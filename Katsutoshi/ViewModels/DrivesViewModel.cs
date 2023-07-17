using Katsutoshi.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Katsutoshi.ViewModels
{
    public class DrivesViewModel : INotifyPropertyChanged
    {
        private DrivesModel drivesModel;
        public ObservableCollection<DriveInfo> drives { get; set; }

        public DrivesViewModel()
        {
            drivesModel = new DrivesModel();
            drives = drivesModel.AllDrives;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
