using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FarsightDash.BaseModules.Views.LineHighlight
{
    public class HighlightModel
    {
        public string RegexPattern { get; set; }
        public SolidColorBrush ForegroundColor { get; set; }
        public SolidColorBrush BackgroundColor { get; set; }
    }
}
