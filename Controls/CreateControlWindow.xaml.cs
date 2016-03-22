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

            ControlSelector.ItemsSource = new List<string>
            {
                ControlNameStrings.DirectoryWatcher,
                ControlNameStrings.FileTail
            };
        }

        private void OKButtonClicked(object sender, RoutedEventArgs e)
        {
            var newControl = new LayoutAnchorable();

            var selectedItem = ControlSelector.SelectedItem;
            if ((string) selectedItem == ControlNameStrings.DirectoryWatcher)
            {
                var newControlContent = new DirectoryWatcher(SelectedPath);
                newControl.Content = newControlContent;
            }

            if ((string)selectedItem == ControlNameStrings.FileTail)
            {
                var newControlContent = new FileTail(SelectedPath);
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
    }
}
