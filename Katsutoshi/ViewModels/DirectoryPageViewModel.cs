using Katsutoshi.Models;
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
        private DirectoryPageModel _model;
        private readonly KatsuLogger logger;

        // Bindable properties
        public ObservableCollection<DirectoryInfo> _folders;
        public ObservableCollection<FileInfo> _files;
        public ObservableCollection<object> _foldersAndFiles;

        private string selectedDirectoryPath = Directory.GetCurrentDirectory();

        // Implementation
        public ObservableCollection<object> foldersAndFiles
        {
            get => _foldersAndFiles;
            set
            {
                _foldersAndFiles = value;
                OnPropertyChanged();
            }
        }

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
            _model = new DirectoryPageModel();
            logger = KatsuLogger.Instance;
        }

        public async Task LoadData()
        {
            try
            {
                folders = await _model.GetAllDirectories(selectedDirectoryPath);
                files = await _model.GetAllFiles(selectedDirectoryPath);

                logger.Log(LogCode.Info, "Test");

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
