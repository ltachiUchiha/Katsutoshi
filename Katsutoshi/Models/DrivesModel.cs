using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Katsutoshi.Models
{
    internal class DrivesModel : INotifyPropertyChanged
    {
        // A task that gets and returns all drives in the system
        public async Task<ObservableCollection<DriveInfo>> GetAllDrives()
        {
            DriveInfo[] allDrives = await Task.Run(() => DriveInfo.GetDrives());
            return new ObservableCollection<DriveInfo>(allDrives);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
