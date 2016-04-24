using System;
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
        private string _TextToHighlight;
        private Color _ForegroundColor;
        private Color _BackgroundColor;

        public LineHighlight(string textToHighlight, Color foregroundColor, Color backgroundColor)
        {
            InitializeComponent();
            _TextToHighlight = textToHighlight;
            _ForegroundColor = foregroundColor;
            _BackgroundColor = backgroundColor;
        }

        public LineHighlight(LineHighlightSaveModel model)
        {
            InitializeComponent();
            _TextToHighlight = model.TextToHighlight;
            _ForegroundColor = model.ForegroundColor;
            _BackgroundColor = model.BackgroundColor;
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
                            if (line.IndexOf(_TextToHighlight, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                lineLabel.Background = new SolidColorBrush(_BackgroundColor);
                                lineLabel.Foreground = new SolidColorBrush(_ForegroundColor);
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
                TextToHighlight = _TextToHighlight,
                ForegroundColor = _ForegroundColor,
                BackgroundColor = _BackgroundColor
            };
            return JsonConvert.SerializeObject(model);
        }

        public UserControl Control { get { return this; } }

        private Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
