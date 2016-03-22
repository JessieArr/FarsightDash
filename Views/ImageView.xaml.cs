using System;
using System.Collections.Generic;
using System.IO;
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
using FarsightDash.DataEmitters;
using FarsightDash.FarsightComponents;
using Newtonsoft.Json;

namespace FarsightDash.Views
{
    /// <summary>
    /// Interaction logic for LabelView.xaml
    /// </summary>
    public partial class ImageView : UserControl, IDataConsumer
    {
        public ImageView()
        {
            InitializeComponent();
        }

        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        var byteArray = JsonConvert.DeserializeObject<byte[]>(args.Data);
                        try
                        {
                            MemoryStream strmImg = new MemoryStream(byteArray);
                            BitmapImage myBitmapImage = new BitmapImage();
                            myBitmapImage.BeginInit();
                            myBitmapImage.StreamSource = strmImg;
                            myBitmapImage.DecodePixelWidth = 531;
                            myBitmapImage.EndInit();

                            ContentImage.Source = myBitmapImage;
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    });
                };
            } 
        }
    }
}
