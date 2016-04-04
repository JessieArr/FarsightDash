using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Themes;

namespace FarsightDash.Themes
{
    public class DarkBlendAvalonDockTheme : Theme
    {
        public override Uri GetResourceUri()
        {
            return new Uri("/Themes/Styles.xaml", UriKind.Relative);
        }
    }
}
