using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;
using Newtonsoft.Json;

namespace FarsightDash.BaseModules.Views.LineHighlight
{
    /// <summary>
    /// Interaction logic for LineHighlight.xaml
    /// </summary>
    public partial class LineHighlight : UserControl, IDataConsumer, IDashboardView, ISavableModule
    {
        private List<HighlightModel> _Highlights;

        public LineHighlight(LineHighlightSaveModel model)
        {
            InitializeComponent();
            _Highlights = model.HighlightValues;
            if (_Highlights == null)
            {
                _Highlights = new List<HighlightModel>();
            }
        }

        public LineHighlight(List<HighlightModel> highlights)
        {
            InitializeComponent();
            _Highlights = highlights;
        }

        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        ContentPanel.Children.Clear();
                        var lines = args.Data.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
                        foreach (var line in lines)
                        {
                            var lineLabel = new System.Windows.Controls.Label()
                            {
                                Content = line,
                                Margin = new Thickness(0, 0, 0, 0),
                                Padding = new Thickness(0, 0, 0, 0)
                            };
                            foreach (var highlight in _Highlights)
                            {
                                var regex = new Regex(highlight.RegexPattern);
                                var match = regex.Match(line);
                                if (match.Success)
                                {
                                    lineLabel.Background = highlight.BackgroundColor;
                                    lineLabel.Foreground = highlight.ForegroundColor;
                                }
                            }
                            ContentPanel.Children.Add(lineLabel);
                        }
                    });
                };
            }
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(LineHighlight); }
        }

        public string GetSaveString()
        {
            var model = new LineHighlightSaveModel()
            {
                HighlightValues = _Highlights
            };
            return JsonConvert.SerializeObject(model);
        }

        public UserControl Control { get { return this; } }
    }
}
