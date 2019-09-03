using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace WebServer1
{
    public class RestApiHandler : IHttpHandler
    {
        public void Handle(WebApp webApp, HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string inputData = ParseRequest(webApp, request);
            string result;
            result = ApiCaller(webApp,request.HttpMethod.ToUpper(), inputData);
            byte[] buffer = Encoding.ASCII.GetBytes(result);
            response.ContentType = "text/html";
            
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        private string ApiCaller(WebApp webApp,string httpMethod, object inputData)
        {
            try
            {
                Assembly DLL = Assembly.LoadFile(webApp.RootDirectory);
                Console.WriteLine(DLL.FullName);
                DLL.GetTypes();
                var theType = DLL.GetType(DLL.FullName.Split(',')[0]+".Service");
                var c = Activator.CreateInstance(theType);
                var method = theType.GetMethod("ProcessRequest");
                var res = method.Invoke(c, new object[] { httpMethod,inputData });
                Console.Write(res);
                return res.ToString();
            }
            catch (Exception exception)
            {
                string responseString = "<HTML><BODY><hr><br><h1>You might have missed something.</h1><br><hr></BODY></HTML>";
                return responseString;
            }
        }

        private string ParseRequest(WebApp webApp, HttpListenerRequest request)
        {
            if (request.HttpMethod.ToUpper() == "POST"){
                var body = new StreamReader(request.InputStream).ReadToEnd();

                return body;
            }
            Uri url = request.Url;
            string filePath = url.AbsolutePath.Remove(0, 1);
            if (filePath.Equals("") || filePath.EndsWith('/'))
                return filePath + "2019";
            return filePath;
        }
        
    }
}