using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer1
{
    public static class HttpHandlerFactory
    {
        public static IHttpHandler GetHttpHandler(string typeOfWebApp)
        {
            switch (typeOfWebApp.ToLower())
            {
                case "static":
                    return new StaticFileHandler();
                case "rest":
                    return new RestApiHandler();
                default:
                    throw new InvalidFileSystemException();
            }
        }
    }
}
