using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Fb2EpubClient
{
    class Fb2EpubBook
    {
        const string hostname = "http://fb2epub.com/";

        public string FilePathInput { get; set; }
        public string FilePathOutput { get; set; }

        public void PostFileToWeb()
        {
            HttpWebRequest request = WebRequest.Create(hostname) as HttpWebRequest;
            request.UserAgent = ".NET Framework Client";
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "multipart/form-data;";




        }

    }
}
