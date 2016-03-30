using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FarsightDash.BaseModules.Controls;
using FarsightDash.Common.Interfaces;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.ModuleSetupViews
{
    /// <summary>
    /// Interaction logic for DirectoryWatcherSetupView.xaml
    /// </summary>
    public partial class DirectoryWatcherSetupView : UserControl, IModuleSetupView
    {
        public DirectoryWatcherSetupView()
        {
            InitializeComponent();
        }

        private string _SelectedPath;

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return !String.IsNullOrEmpty(_SelectedPath);
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var module = new DirectoryWatcher(_SelectedPath);
            return new List<IFarsightDashModule>()
            {
                module
            };
        }

        private void DirectorySelectButton_Click(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            _SelectedPath = fbd.SelectedPath;
        }
    }
}
