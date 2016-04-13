using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Layout;
using CreateControlWindow = FarsightDash.CreateControlWindow;

namespace FarsightDash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SaveFileHelper _SaveFileHelper;
        public MainWindow()
        {
            InitializeComponent();
            DockHelper.RootAnchorablePane = AnchorablePane;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            _SaveFileHelper = new SaveFileHelper();
            if (File.Exists("Autosave.ini"))
            {
                _SaveFileHelper.LoadSavedModuleFromFile("Autosave.ini");
            }
        }

        private void ExitMenuItemClicked(object sender, RoutedEventArgs e)
        {
            _SaveFileHelper.Autosave();

            Application.Current.Shutdown();
        }

        private void CreateControlClicked(object sender, RoutedEventArgs e)
        {
            var popupWindow = new Window();
            var createControlWindowContent = new CreateControlWindow();
            popupWindow.Content = createControlWindowContent;
            popupWindow.Owner = this;
            popupWindow.Height = 500;
            popupWindow.Width = 650;
            popupWindow.Show();
        }

        private void SaveMenuItemClicked(object sender, RoutedEventArgs e)
        {
            _SaveFileHelper.Autosave();
        }

        private void ManageControlsClicked(object sender, RoutedEventArgs e)
        {
            var popupWindow = new Window();

            var scrollViewer = new ScrollViewer();
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            var manageControlsWindowContent = new ManageControlsWindow();

            scrollViewer.Content = manageControlsWindowContent;
            popupWindow.Content = scrollViewer;
            popupWindow.Owner = this;
            popupWindow.Height = 500;
            popupWindow.Width = 650;
            popupWindow.Show();
        }

        private bool _IsFullScreen { get; set; }
        private void ToggleFullscreenMenuItemClicked(object sender, RoutedEventArgs e)
        {
            if (_IsFullScreen)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                TopBarMenu.Visibility = Visibility.Visible;

                _IsFullScreen = false;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                TopBarMenu.Visibility = Visibility.Collapsed;

                _IsFullScreen = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F11:
                    ToggleFullscreenMenuItemClicked(this, new RoutedEventArgs());
                    return;
            }
        }
    }
}
