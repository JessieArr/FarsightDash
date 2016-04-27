using System;
using System.Collections.Generic;
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
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Network.Ping
{
    /// <summary>
    /// Interaction logic for PingModuleSetupView.xaml
    /// </summary>
    public partial class PingModuleSetupView : UserControl, IModuleSetupView
    {
        public PingModuleSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control { get { return this; } }
        public bool IsEnteredUserDataValid()
        {
            return true;
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var module = new Ping(URLTextBox.Text);
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
