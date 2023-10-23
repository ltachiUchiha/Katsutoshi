using Katsutoshi.Modules;
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
    internal class DirectoryPageViewModel : INotifyPropertyChanged
    {
        private readonly KatsuLogger logger;

        // Bindable properties
        public ObservableCollection<DirectoryInfo> _folders;
        public ObservableCollection<FileInfo> _files;

        // Implementation
        public ObservableCollection<DirectoryInfo> folders
        {
            get => _folders;
            set
            {
                _folders = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FileInfo> files
        {
            get => _files;
            set
            {
                _files = value;
                OnPropertyChanged();
            }
        }

        public DirectoryPageViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
