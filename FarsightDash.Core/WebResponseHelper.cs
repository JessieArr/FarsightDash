using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarsightDash.BaseModules
{
    public class WebResponseHelper : IWebResponseHelper
    {
        public IHttpWebResponseWrapper GetResponseFromURL(string url)
        {
            return new HttpWebResponseWrapper(url);
        }
    }

    public interface IWebResponseHelper
    {
        IHttpWebResponseWrapper GetResponseFromURL(string url);
    }
}
