using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FarsightDash.Common.Interfaces;
using Xceed.Wpf.Toolkit;

namespace FarsightDash.BaseModules.Views.LineHighlight
{
    /// <summary>
    /// Interaction logic for LineHighlightSetupView.xaml
    /// </summary>
    public partial class LineHighlightSetupView : UserControl, IModuleSetupView
    {
        private ObservableCollection<HighlightModel> _Highlights; 
        public LineHighlightSetupView()
        {
            InitializeComponent();
            _Highlights = new ObservableCollection<HighlightModel>()
            {
                new HighlightModel()
                {
                    RegexPattern = "",
                    ForegroundColor = new SolidColorBrush(Colors.White),
                    BackgroundColor = new SolidColorBrush(Colors.White)
                }
            };
            MainGrid.ItemsSource = _Highlights;
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return true;
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var module = new LineHighlight(_Highlights.ToList());
            return new List<IFarsightDashModule>()
            {
                module
            };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _Highlights.Add(new HighlightModel()
            {
                RegexPattern = "",
                ForegroundColor = new SolidColorBrush(Colors.White),
                BackgroundColor = new SolidColorBrush(Colors.White)
            });
        }
    }
}
