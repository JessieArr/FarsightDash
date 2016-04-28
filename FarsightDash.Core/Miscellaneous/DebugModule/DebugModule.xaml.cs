using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Miscellaneous.DebugModule
{
    /// <summary>
    /// Interaction logic for DebugModule.xaml
    /// </summary>
    public partial class DebugModule : UserControl, IDashboardView, ITransform, ISavableModule
    {
        public DebugModule()
        {
            InitializeComponent();
        }

        public DebugModule(string savedText)
        {
            InitializeComponent();
            DataTextBox.Text = savedText;
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(DebugModule); } }
        public string GetSaveString()
        {
            return DataTextBox.Text;
        }

        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        DataTextBox.Text = args.Data;
                    });
                };
            }
        }

        private void EmitFreshData()
        {
            if (EmitData != null)
            {
                EmitData(this, new EmitDataHandlerArgs(DataTextBox.Text));
            }
        }

        public event EmitDataHandler EmitData;

        public void Initialize()
        {
            EmitFreshData();
        }

        public UserControl Control { get { return this; } }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            EmitFreshData();
        }
    }
}
