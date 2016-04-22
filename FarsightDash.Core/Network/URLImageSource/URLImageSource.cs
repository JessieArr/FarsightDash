using System;
using System.Net;
using System.Timers;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using Newtonsoft.Json;

namespace FarsightDash.BaseModules.Network.URLImageSource
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
            webClient.UseDefaultCredentials = true;
            try
            {
                byte[] imageBytes = webClient.DownloadData(_URL);
                return imageBytes;
            }
            catch (Exception ex)
            {
                FarsightLogger.DefaultLogger.LogError(ex.Message);
                return null;
            }
        }

        public void Initialize()
        {
            var bitmap = GetBitmapFromURL();
            var serializedData = JsonConvert.SerializeObject(bitmap);
            EmitData(this, new EmitDataHandlerArgs(serializedData));
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(URLImageSource); }
        }
    }
}
