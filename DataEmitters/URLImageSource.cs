using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media.Imaging;
using FarsightDash.FarsightComponents;
using FarsightDash.FarsightComponents.Models;
using Newtonsoft.Json;

namespace FarsightDash.DataEmitters
{
    public class URLImageSource : IDataEmitter
    {
        public event EmitDataHandler EmitData;

        private string _URL;
        private int _IntervalInSeconds;
        private const int _MillisecondsPerSecond = 1000;
        private Timer _Timer;

        public URLImageSource(string url, int intervalInSeconds)
        {
            _URL = url;

            _IntervalInSeconds = intervalInSeconds;

            _Timer = new Timer(intervalInSeconds * _MillisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                var bitmap = GetBitmapFromURL();
                var serializedData = JsonConvert.SerializeObject(bitmap);
                EmitData(this, new EmitDataHandlerArgs(serializedData));
            };
            _Timer.Enabled = true;
        }

        private byte[] GetBitmapFromURL()
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(_URL);
            return imageBytes;
        }

        public void Initialize()
        {
            var bitmap = GetBitmapFromURL();
            var serializedData = JsonConvert.SerializeObject(bitmap);
            EmitData(this, new EmitDataHandlerArgs(serializedData));
        }
    }
}
