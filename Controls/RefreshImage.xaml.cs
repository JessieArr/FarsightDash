using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common;

namespace FarsightDash.Controls
{
    /// <summary>
    /// Interaction logic for RefreshImage.xaml
    /// </summary>
    public partial class RefreshImage : UserControl
    {
        private IDataEmitter _DataEmitter;
        private ImageView _View;

        public RefreshImage(string url, int intervalInSeconds)
        {
            InitializeComponent();

            _DataEmitter = new URLImageSource(url, intervalInSeconds);
            _View = new ImageView();

            _DataEmitter.EmitData += _View.DataHandler;
            _DataEmitter.Initialize();

            Content = _View;
        }
    }
}
