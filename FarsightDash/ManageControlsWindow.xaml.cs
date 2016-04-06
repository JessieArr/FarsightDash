using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            ControlGrid.ItemsSource = registry.GetRegisteredControlData().OrderBy(x => x.ModuleName);

            ActionsComboBox.ItemsSource = new[] { DeleteActionString, ConnectDataConsumerString };
        }

        private const string DeleteActionString = "Delete Module";
        private const string ConnectDataConsumerString = "Connect Data Consumer";

        private void SubmitButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedValue = ActionsComboBox.Text;

            if (selectedValue == DeleteActionString)
            {
                DeleteAction();
            }
            if (selectedValue == ConnectDataConsumerString)
            {
                ConnectDataConsumer();
            }
        }

        private void ConnectDataConsumer()
        {
            var registry = ModuleRegistry.DefaultRegistry;
            var selectedModuleData = (ModuleManagementData)ControlGrid.SelectedItem;
            var moduleToBeConnectedData = (ModuleManagementData)ControlToBeConnectedGrid.SelectedItem;

            var selectedModule = registry.GetRegisteredModule(selectedModuleData.ModuleName);
            var moduleToBeConnected = registry.GetRegisteredModule(moduleToBeConnectedData.ModuleName);

            registry.ConsumeData(selectedModule, moduleToBeConnected);
            CloseParentWindow();
        }

        private void DeleteAction()
        {
            var registry = ModuleRegistry.DefaultRegistry;
            var selectedModuleData = (ModuleManagementData)ControlGrid.SelectedItem;
            var moduleToUnregister = registry.GetRegisteredModule(selectedModuleData.ModuleName);
            registry.UnregisterModule(moduleToUnregister);
            CloseParentWindow();
        }

        private void CloseParentWindow()
        {
            ((Window)Parent).Close();
        }

        private void ControlGridSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (ControlGrid.SelectedItem != null)
            {
                Dispatcher.Invoke(() =>
                {
                    SubmitButton.IsEnabled = true;
                });
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    SubmitButton.IsEnabled = false;
                });
            }

            var selectedValue = ActionsComboBox.Text;
            if (selectedValue == ConnectDataConsumerString)
            {
                var registry = ModuleRegistry.DefaultRegistry;
                var controls = registry.GetRegisteredControlData().Where(x => x.IsDataConsumer);

                ControlToBeConnectedGrid.ItemsSource = controls;
            }
        }
    }
}
