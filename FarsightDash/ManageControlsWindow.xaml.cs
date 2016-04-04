using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using FarsightDash.BaseModules;
using FarsightDash.BaseModules.Controls;
using FarsightDash.BaseModules.ModuleFactories;
using FarsightDash.Common.Interfaces;
using Xceed.Wpf.AvalonDock.Layout;
using Label = System.Windows.Controls.Label;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash
{
    /// <summary>
    /// Interaction logic for ManageControlsWindow.xaml
    /// </summary>
    public partial class ManageControlsWindow : UserControl
    {
        public ManageControlsWindow()
        {
            InitializeComponent();

            var registry = ModuleRegistry.DefaultRegistry;
            ControlGrid.ItemsSource = registry.GetRegisteredControlNames();
        }
    }
}
