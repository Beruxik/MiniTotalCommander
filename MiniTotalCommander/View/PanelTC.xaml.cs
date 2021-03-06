using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTotalCommander.View
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        private static readonly DependencyProperty CurrentPathProperty =
            DependencyProperty.Register(nameof(CurrentPath), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        private static readonly DependencyProperty CurrentFileProperty =
            DependencyProperty.Register(nameof(CurrentFile), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        private static readonly DependencyProperty AllFilesProperty =
            DependencyProperty.Register(nameof(AllFiles), typeof(ObservableCollection<string>), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        private static readonly DependencyProperty AllDrivesProperty =
            DependencyProperty.Register(nameof(AllDrives), typeof(ObservableCollection<string>), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public PanelTC()
        {
            InitializeComponent();
        }

        public string CurrentPath
        {
            get { return (string)GetValue(CurrentPathProperty); }
            set { SetValue(CurrentPathProperty, value); }
        }

        public string CurrentFile
        {
            get { return (string)GetValue(CurrentFileProperty); }
            set { SetValue(CurrentFileProperty, value); }
        }

        public ObservableCollection<string> AllFiles
        {
            get { return (ObservableCollection<string>)GetValue(AllFilesProperty); }
            set { SetValue(AllFilesProperty, value); }
        }

        public ObservableCollection<string[]> AllDrives
        {
            get { return (ObservableCollection<string[]>)GetValue(AllDrivesProperty); }
            set { SetValue(AllDrivesProperty, value); }
        }

        private void DriveChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentPath = e.AddedItems[0].ToString();
        }
    }
}
