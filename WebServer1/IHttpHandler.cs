using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer1
{
    public interface IHttpHandler
    {
        WebApp WebApp { get; }
    }
    public class StaticFileHandler :IHttpHandler
    {
        public WebApp WebApp { get; }
        public StaticFileHandler(WebApp webApp)
        {
            this.WebApp = webApp;
        }


    }
}
