using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

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
