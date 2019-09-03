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
            WebApp webApp1 = new WebApp("secondWebsite", @"C:\Users\gsanap\Desktop\HtmlAssignments\Todo\", "static", "local");
            string prefix1 = "http://bbbbbbbb.com/";
            webAppList.AddWebApp(prefix1, webApp1);

            WebApp webApp2 = new WebApp("firstWebAPI", @"C:\Users\gsanap\source\repos\LeapYear\LeapYear\bin\Debug\netcoreapp2.2\LeapYear.dll", "rest", "local");
            string prefix2 = "http://firstwebsite.com/";
            webAppList.AddWebApp(prefix2, webApp2);
            Server server = new Server(webAppList);
            new ServerAdministrator().StartServer(server);
        }
    }
}
