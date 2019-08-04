using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebServer1
{
    public interface IHttpHandler
    {
        void Handle(WebApp webApp, HttpListenerContext httpListenerContext);
    }
}
