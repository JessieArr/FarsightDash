using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using Newtonsoft.Json;

namespace FarsightDash.BaseModules.Views.Image
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

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(ImageView); }
        }
    }
}
