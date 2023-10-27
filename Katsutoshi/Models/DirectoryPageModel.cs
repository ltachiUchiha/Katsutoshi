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
    internal class DirectoryPageModel : INotifyPropertyChanged
    {
        public async Task<ObservableCollection<DirectoryInfo>> GetAllDirectories(string directoryPath)
        {
            var allDirectories = await Task.Run(() => Directory.GetDirectories(directoryPath)
                .Select(file => new DirectoryInfo(file)));

            return new ObservableCollection<DirectoryInfo>(allDirectories);
        }

        public async Task<ObservableCollection<FileInfo>> GetAllFiles(string directoryPath)
        {
            var allFIles = await Task.Run(() => Directory.GetFiles(directoryPath)
                .Select(file => new FileInfo(file)));

            return new ObservableCollection<FileInfo>(allFIles);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
