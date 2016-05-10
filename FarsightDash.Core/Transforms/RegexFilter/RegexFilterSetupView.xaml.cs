using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Transforms.RegexFilter
{
    /// <summary>
    /// Interaction logic for RegexFilterSetupView.xaml
    /// </summary>
    public partial class RegexFilterSetupView : UserControl, IModuleSetupView
    {
        public RegexFilterSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return !String.IsNullOrEmpty(RegexFilterTextBox.Text);
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            RegexReturnTypeEnum returnType = RegexReturnTypeEnum.FirstMatch;
            if (ReturnFirstMatch.IsChecked == true)
            {
                returnType = RegexReturnTypeEnum.FirstMatch;
            }
            if (ReturnLastMatch.IsChecked == true)
            {
                returnType = RegexReturnTypeEnum.LastMatch;
            }
            if (ReturnAllMatches.IsChecked == true)
            {
                returnType = RegexReturnTypeEnum.AllMatches;
            }

            string separator = Environment.NewLine;
            if (SeparateWithText.IsChecked == true)
            {
                separator = SeparatorText.Text;
            }

            var filter = new RegexFilter(RegexFilterTextBox.Text, returnType, separator);
            return new List<IFarsightDashModule>()
            {
                filter
            };
        }
    }
}
