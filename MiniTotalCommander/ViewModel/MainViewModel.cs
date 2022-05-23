using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniTotalCommander.ViewModel
{
    using MiniTotalCommander.View;
    using Model;
    internal class MainViewModel : INotifyPropertyChanged
    {
        Model Model = new Model();

        private string _currDirLeft = null;

        public string CurrDirLeft
        {
            get { return _currDirLeft; }
            set
            {
                _currDirLeft = value;
                OnPropertyChanged(nameof(CurrDirLeft));
                OnPropertyChanged(nameof(CurrFilesLeft));
            }
        }

        public ObservableCollection<string> CurrFilesLeft
        {
            get { return new ObservableCollection<string>(Model.GetFiles(CurrDirLeft)); }
        }

        private string _currDirRight = null;

        public string CurrDirRight
        {
            get { return _currDirRight; }
            set
            {
                _currDirRight = value;
                OnPropertyChanged(nameof(CurrDirRight));
                OnPropertyChanged(nameof(CurrFilesRight));
            }
        }

        public ObservableCollection<string> CurrFilesRight
        {
            get { return new ObservableCollection<string>(Model.GetFiles(CurrDirRight)); }
        }

        public ObservableCollection<string> GetDrives
        {
            get { return new ObservableCollection<string>(Model.GetDrives()); }
        }

        public string SelectedFile { get; set; }

        private ICommand _clickLeft = null;
        public ICommand ClickLeft
        {
            get
            {
                if (_clickLeft == null)
                {
                    _clickLeft = new RelayCommand(
                        x => { CurrDirLeft = Model.ChangePath(CurrDirLeft, SelectedFile); },
                        x => true);
                }
                return _clickLeft;
            }
        }

        private ICommand _clickRight = null;
        public ICommand ClickRight
        {
            get
            {
                if (_clickRight == null)
                {
                    _clickRight = new RelayCommand(
                        x => { CurrDirRight = Model.ChangePath(CurrDirRight, SelectedFile); },
                        x => true);
                }
                return _clickRight;
            }
        }

        private ICommand _copy = null;
        public ICommand Copy
        {
            get
            {
                if (_copy == null)
                {
                    _copy = new RelayCommand(x =>
                    {
                        if (CurrDirRight != null)
                        {
                            string source = CurrDirLeft + @"\" + SelectedFile;
                            string destination = _currDirRight + @"\" + SelectedFile;

                            Model.CopyFile(source, destination);
                            if (!SelectedFile.StartsWith("<D> "))
                                MessageBox.Show($"{SelectedFile} copied successfully!");
                        }

                        OnPropertyChanged(nameof(CurrFilesRight));
                    },
                    x => true);
                }
                return _copy;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
