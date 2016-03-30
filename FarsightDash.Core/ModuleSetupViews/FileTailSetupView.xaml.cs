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
