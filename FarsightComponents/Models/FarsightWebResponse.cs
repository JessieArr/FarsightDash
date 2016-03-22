using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FarsightDash.FarsightComponents.Models
{
    public class FarsightWebResponse
    {
        public Uri ResponseUri { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public FarsightWebResponse()
        {
        }

            public FarsightWebResponse(HttpWebResponse response)
        {
            ResponseUri = response.ResponseUri;
            StatusCode = response.StatusCode;
        }
    }
}
