using Katsutoshi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
