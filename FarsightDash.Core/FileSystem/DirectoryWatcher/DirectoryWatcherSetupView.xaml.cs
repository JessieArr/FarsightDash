using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using FarsightDash.Common.Interfaces;
using DirectoryWatcher = FarsightDash.BaseModules.FileSystem.DirectoryWatcher.DirectoryWatcher;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.FileSystem.DirectoryWatcher
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
