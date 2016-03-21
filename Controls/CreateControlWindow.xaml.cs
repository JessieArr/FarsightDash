using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Xceed.Wpf.AvalonDock.Layout;
using Label = System.Windows.Controls.Label;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.Controls
{
    /// <summary>
    /// Interaction logic for CreateControlWindow.xaml
    /// </summary>
    public partial class CreateControlWindow : UserControl
    {
        public CreateControlWindow()
        {
            InitializeComponent();
        }

        private void OKButtonClicked(object sender, RoutedEventArgs e)
        {
            var newControl = new LayoutAnchorable();
            var newControlContent = new DirectoryWatcher(SelectedPath);
            newControl.Content = newControlContent;
            newControl.Title = "New Control";
            DockHelper.RootAnchorablePane.Children.Add(newControl);

            var parentWindow = (Window)Parent;
            parentWindow.Close();
        }

        private void SelectTargetClicked(object sender, RoutedEventArgs e)
        {
            //var selectedItem = (ComboBoxItem)ControlSelector.SelectedItem;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            SelectedPath = fbd.SelectedPath;
        }

        private string SelectedPath;
    }
}
