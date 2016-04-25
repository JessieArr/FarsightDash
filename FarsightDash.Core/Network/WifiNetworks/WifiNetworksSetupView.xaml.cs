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

namespace FarsightDash.BaseModules.Network.WifiNetworks
{
    /// <summary>
    /// Interaction logic for WifiNetworksSetupView.xaml
    /// </summary>
    public partial class WifiNetworksSetupView : IModuleSetupView
    {
        public WifiNetworksSetupView()
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
            var module = new WifiNetworks();
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
