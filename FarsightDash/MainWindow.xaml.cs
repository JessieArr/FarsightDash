﻿using System;
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
            popupWindow.Width = 400;
            popupWindow.Height = 400;
            popupWindow.Show();
        }

        private void SaveMenuItemClicked(object sender, RoutedEventArgs e)
        {
            _SaveFileHelper.Autosave();
        }
    }
}
