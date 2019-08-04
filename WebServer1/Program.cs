using System;

namespace WebServer1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebAppList webAppList = new WebAppList();
            WebApp webApp = new WebApp("firstWebsite", @"C:\Users\gsanap\Desktop\", "static", "local");
            string prefix = "http://aaaaaaaa.com/";
            webAppList.AddWebApp(prefix,webApp);
            WebApp webApp1 = new WebApp("secondWebsite", @"C:\Users\gsanap\Desktop\status\", "static", "local");
            string prefix1 = "http://bbbbbbbb.com/";
            webAppList.AddWebApp(prefix1, webApp1);
            Server server = new Server(webAppList);
            new ServerAdministrator().StartServer(server);
        }
    }
}
