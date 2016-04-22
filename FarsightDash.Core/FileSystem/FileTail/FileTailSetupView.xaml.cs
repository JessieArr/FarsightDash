using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using FarsightDash.Common.Interfaces;
using FileTail = FarsightDash.BaseModules.FileSystem.FileTail.FileTail;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.FileSystem.FileTail
{
    /// <summary>
    /// Interaction logic for FileTailSetupView.xaml
    /// </summary>
    public partial class FileTailSetupView : UserControl, IModuleSetupView
    {
        public FileTailSetupView()
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
            var module = new FileTail(_SelectedPath);
            return new List<IFarsightDashModule>()
            {
                module
            };
        }

        private void FileSelectButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();
            _SelectedPath = fileDialog.FileName;
        }
    }
}
