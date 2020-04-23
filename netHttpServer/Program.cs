using System;
using System.Net;
using System.IO;

namespace netHttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.StartServer();

            Console.ReadLine();
        }
    }
}
