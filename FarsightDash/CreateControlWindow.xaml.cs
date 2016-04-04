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
    /// Interaction logic for CreateControlWindow.xaml
    /// </summary>
    public partial class CreateControlWindow : UserControl
    {
        public CreateControlWindow()
        {
            InitializeComponent();

            var registry = ModuleFactoryRegistry.DefaultRegistry;
            ControlSelector.ItemsSource = registry.GetAllRegisteredFactoryNames();
        }

        private IModuleSetupView _CurrentModuleSetupView;

        private void OKButtonClicked(object sender, RoutedEventArgs e)
        {
            var newControl = new LayoutAnchorable();
            
            if (_CurrentModuleSetupView.IsEnteredUserDataValid())
            {
                var modules = _CurrentModuleSetupView.CreateModules(null);
                // TODO: Handle more than one returned module here!
                var firstModule = modules[0];
                firstModule.ModuleName = ControlName.Text;

                newControl.Content = firstModule;
                ModuleRegistry.DefaultRegistry.RegisterModule(firstModule);

                newControl.Hiding += (o, args) =>
                {
                    ModuleRegistry.DefaultRegistry.UnregisterModule(firstModule);
                };
            }

            newControl.Title = ControlName.Text;
            


            DockHelper.RootAnchorablePane.Children.Add(newControl);

            var parentWindow = (Window)Parent;
            parentWindow.Close();
        }

        private void SelectTargetClicked(object sender, RoutedEventArgs e)
        {
            var selectedItem = ControlSelector.SelectedItem;

            if ((string)selectedItem == ControlNameStrings.DirectoryWatcher)
            {
                var fbd = new FolderBrowserDialog();
                var result = fbd.ShowDialog();
                SelectedPath = fbd.SelectedPath;
            }

            if ((string)selectedItem == ControlNameStrings.FileTail)
            {
                var fbd = new OpenFileDialog();
                var result = fbd.ShowDialog();
                SelectedPath = fbd.FileName;
            }
        }

        private string SelectedPath;

        private void ControlSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = (string)ControlSelector.SelectedItem;
            var registry = ModuleFactoryRegistry.DefaultRegistry;

            var factory = registry.GetModuleFactory(selectedItem);

            _CurrentModuleSetupView = factory.GetNewModuleSetupView(ModuleRegistry.DefaultRegistry);
            ModuleCreationPanel.Children.Add(_CurrentModuleSetupView.Control);
        }
    }
}
