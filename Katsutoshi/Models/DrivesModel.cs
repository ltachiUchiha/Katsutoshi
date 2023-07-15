using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Katsutoshi.Models
{
    internal class DrivesModel : INotifyPropertyChanged
    {
        public ObservableCollection<DriveInfo> AllDrives
        {
            get
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                return new ObservableCollection<DriveInfo>(allDrives);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
