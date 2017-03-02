using System.Windows;
using System.Windows.Forms;
using FarsightDash.BaseModules;
using FarsightDash.BaseModules.Miscellaneous.PopUp;
using FarsightDash.Common.Interfaces;
using MessageBox = System.Windows.Forms.MessageBox;
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
            if (_CurrentModuleSetupView.IsEnteredUserDataValid())
            {
                if (ModuleRegistry.DefaultRegistry.IsModuleRegistered(ControlName.Text))
                {
                    MessageBox.Show("A module with that name is already declared. Module names must be unique.", "Duplicate Module");
                    return;
                }
                var modules = _CurrentModuleSetupView.CreateModules(null);
                // TODO: Handle more than one returned module here!
                var firstModule = modules[0];
                firstModule.ModuleName = ControlName.Text;

                ModuleRegistry.DefaultRegistry.RegisterModule(firstModule);

                var view = firstModule as IDashboardView;
                if(view != null)
                {
                    var anchorableService = new AnchorableViewService();
                    var newAnchorable = anchorableService.GetAnchorableFromView(view);

                    newAnchorable.Hiding += (obj, args) =>
                    {
                        ModuleRegistry.DefaultRegistry.UnregisterModule(view);
                    };

                    DockHelper.RootAnchorablePane.Children.Add(newAnchorable);
                }


                var parentWindow = (Window)Parent;
                parentWindow.Close();
            }
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

            if (_CurrentModuleSetupView != null && ModuleCreationPanel.Children.Contains(_CurrentModuleSetupView.Control))
            {
                ModuleCreationPanel.Children.Remove(_CurrentModuleSetupView.Control);
            }

            _CurrentModuleSetupView = factory.GetNewModuleSetupView(ModuleRegistry.DefaultRegistry);
            ModuleCreationPanel.Children.Add(_CurrentModuleSetupView.Control);
        }
    }
}
