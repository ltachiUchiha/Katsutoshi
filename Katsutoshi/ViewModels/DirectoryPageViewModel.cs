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
        public List<FileSystemInfo> _folders;
        public List<FileSystemInfo> _files;
        public ObservableCollection<FileSystemInfo> _foldersAndFiles = new ObservableCollection<FileSystemInfo>();

        private string _selectedDirectoryPath;

        // Implementation
        public ObservableCollection<FileSystemInfo> foldersAndFiles
        {
            get => _foldersAndFiles;
            set
            {
                _foldersAndFiles = value;
                OnPropertyChanged();
            }
        }

        public DirectoryPageViewModel(string selectedDirectoryPath)
        {
            _model = new DirectoryPageModel();
            logger = KatsuLogger.Instance;

            _selectedDirectoryPath = selectedDirectoryPath;
        }

        public async Task LoadData()
        {
            try
            {
                _folders = await _model.GetAllDirectories(_selectedDirectoryPath);
                _files = await _model.GetAllFiles(_selectedDirectoryPath);
                _folders.AddRange(_files);
                foldersAndFiles = new ObservableCollection<FileSystemInfo>(_folders);

                /*
                foreach (var folder in folders)
                {
                    foldersAndFiles.Add(folder);
                }
                foreach (var file in files)
                {
                    foldersAndFiles.Add(file);
                }
                */

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
            logger.Log(LogCode.Info, "Some changes");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
