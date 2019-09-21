using System;
using System.Net;

namespace Wincubate.Solid.Module01
{
    class WebStorage : IReadStorage
    {
        public string Url { get; }

        public WebStorage( string url )
        {
            Url = url;
        }

        public string GetDataAsString()
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(Url);
            }
        }
    }
}
