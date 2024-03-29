﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace WebServer1
{
    public class ServerAdministrator
    {
        public void StartServer(Server server)
        {
            if (server.Listener != null)
            {
                if (server.Listener.IsListening)
                {
                    Console.WriteLine("Server is Already Running");
                    return;
                }
            }
            else
            {
                string[] prefixes = server.Prefixes;

                // Create a listener.
                server.Listener = new HttpListener();
                // Add the prefixes.
                foreach (string prefix in prefixes)
                {
                    server.Listener.Prefixes.Add(prefix);
                }
            }
            Thread listenerThread = new Thread(new ThreadStart(() => this.StartListening(server)));
            listenerThread.Start();
        }
        public void StopServer(Server server)
        {
            if (server.Listener == null)
            {
                Console.WriteLine("Server was never started");
                return;
            }
            else
            {
                if (server.Listener.IsListening)
                {
                    server.Listener.Stop();
                    Console.WriteLine("Server Stopped");
                }
                else
                {
                    Console.WriteLine("Server was stopped already");
                }
            }
        }

        private void StartListening(Server server)
        {
            server.Listener.Start();
            Console.WriteLine("Server Started Listening on {0}", string.Join(", ", server.Prefixes));
            // Note: The GetContext method blocks while waiting for a request. 
            while (server.Listener.IsListening)
            {
                HttpListenerContext context = server.Listener.GetContext();
                Dispatcher dispatcher = new Dispatcher();
                Thread dispatcherThread = new Thread(new ThreadStart(() => dispatcher.Dispatch(server, context)));
                dispatcherThread.Start();
            }
            Console.WriteLine("Server Stopped Listening");
        }

        public void AddWebApp(Server server, string prefix, WebApp webApp)
        {
            if (server.Listener != null)
            {
                if (server.Listener.IsListening)
                {
                    StopServer(server);
                }
            }
            server.WebAppList.AddWebApp(prefix, webApp);
            server.Prefixes[server.Prefixes.Length] = prefix;
        }

        public void RemoveWebApp(Server server, string prefix)
        {
            if (server.Listener != null)
            {
                if (server.Listener.IsListening)
                {
                    StopServer(server);
                }
            }
            server.WebAppList.RemoveWebApp(prefix);
            server.Prefixes = new string[server.WebAppList._webAppList.Keys.Count];
            var j = 0;
            foreach(var i in server.WebAppList._webAppList.Keys)
            {
                server.Prefixes[j]=i;
                j++;
            }
        }
    }
}
