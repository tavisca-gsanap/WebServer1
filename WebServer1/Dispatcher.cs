using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebServer1
{
    public class Dispatcher
    {
        public void Dispatch(Server server, HttpListenerContext httpListenerContext)
        {
            var url = httpListenerContext.Request.Url;
            try
            {
                WebApp webApp = server.WebAppList.GetWebApp(url.GetLeftPart(new UriPartial()) + url.Host + "/");
                webApp.Handler.Handle(webApp, httpListenerContext);
            }
            catch(WebAppNotFoundException exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
