using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace netHttpServer
{
    public class Server
    {
        public static Task StartServer()
        {
            HttpListener listener = new HttpListener();

            string[] prefix =
            {
                "http://localhost:" + Configuration.port + "/",
                "http://" + Classes.GetLocalIPAddress() + ":" + Configuration.port + "/",
            };

            foreach (string str in prefix)
            {
                listener.Prefixes.Add(str);
                Console.WriteLine(str);
            }
            Console.WriteLine("http://" + Classes.getExternalIp() + ":" + Configuration.port + "/");
            
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                Task.Run(() => Client.ClientHandler(listener, context));
            }
        }
    }
}
