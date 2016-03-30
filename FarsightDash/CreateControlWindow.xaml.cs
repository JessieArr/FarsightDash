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

            ControlSelector.ItemsSource = new List<string>
            {
                ControlNameStrings.DirectoryWatcher,
                ControlNameStrings.FileTail,
                ControlNameStrings.Clock,
                ControlNameStrings.Date,
                ControlNameStrings.HTTPStatusMonitor,
                ControlNameStrings.RefreshImage,
                ControlNameStrings.ChromiumBrowser
            };
        }

        private IModuleSetupView _CurrentModuleSetupView;

        private void OKButtonClicked(object sender, RoutedEventArgs e)
        {
            var newControl = new LayoutAnchorable();

            var selectedItem = (string)ControlSelector.SelectedItem;
            if ( selectedItem == ControlNameStrings.DirectoryWatcher)
            {
                var newControlContent = new DirectoryWatcher(SelectedPath);
                newControl.Content = newControlContent;
            }

            if (selectedItem == ControlNameStrings.FileTail)
            {
                var newControlContent = new FileTail(SelectedPath);
                newControl.Content = newControlContent;
            }

            if (selectedItem == ControlNameStrings.Clock)
            {
                var newControlContent = new Clock();
                newControl.Content = newControlContent;
            }

            if (selectedItem == ControlNameStrings.Date)
            {
                var newControlContent = new Date();
                newControl.Content = newControlContent;
            }

            if (selectedItem == ControlNameStrings.HTTPStatusMonitor)
            {
                var newControlContent = new HTTPStatusMonitor(ControlName.Text, 10);
                newControl.Content = newControlContent;
            }

            if (selectedItem == ControlNameStrings.RefreshImage)
            {
                var newControlContent = new RefreshImage(ControlName.Text, 10);
                newControl.Content = newControlContent;
            }

            if (selectedItem == ControlNameStrings.ChromiumBrowser)
            {
                var newControlContent = new ChromiumBrowserPane(ControlName.Text);
                newControl.Content = newControlContent;
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
            if (selectedItem == ControlNameStrings.ChromiumBrowser)
            {
                _CurrentModuleSetupView = new ChromiumBrowserModuleFactory().GetNewModuleSetupView();
                ModuleCreationPanel.Children.Add(_CurrentModuleSetupView.Control);
            }
        }
    }
}
