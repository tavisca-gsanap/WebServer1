using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebServer1
{
    public class Server
    {
        //public int Id { get; }
        public string[] Prefixes { get; set; }
        //public string RootDirectory { get; }
        public HttpListener Listener { get; set; }
        public WebAppList WebAppList { get; }

        public Server(WebAppList webAppList)
        {
            WebAppList = webAppList;
            string[] prefixes = new string[webAppList._webAppList.Keys.Count];
            webAppList._webAppList.Keys.CopyTo(prefixes, 0);
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");
            //this.Id = id;
            this.Prefixes = prefixes;
            //this.RootDirectory = rootDirectory;
        }
    }
}
