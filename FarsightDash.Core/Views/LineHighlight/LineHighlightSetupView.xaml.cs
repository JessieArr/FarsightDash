using System;
using System.Collections.Generic;
using FarsightDash.Common.Interfaces;
using TextBoxView = FarsightDash.BaseModules.Views.TextBox.TextBoxView;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.Views.LineHighlight
{
    /// <summary>
    /// Interaction logic for LineHighlightSetupView.xaml
    /// </summary>
    public partial class LineHighlightSetupView : UserControl, IModuleSetupView
    {
        public LineHighlightSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return HighlightText.Text.Length > 0 && ForegroundColor.SelectedColor.HasValue 
                && BackgroundColor.SelectedColor.HasValue;
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            if (!ForegroundColor.SelectedColor.HasValue || !BackgroundColor.SelectedColor.HasValue)
            {
                throw new Exception("Colors cannot be null.");
            }
            var module = new LineHighlight(HighlightText.Text, 
                ForegroundColor.SelectedColor.Value, BackgroundColor.SelectedColor.Value);
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
