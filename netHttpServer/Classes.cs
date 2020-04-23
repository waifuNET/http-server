using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace netHttpServer
{
    public class Classes
    {
        public static string getStartupPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static string getHTTPContentType(string Extension)
        {
            string result = null;
            try
            {
                result = Configuration.HTTPContentType[Extension];
            }
            catch 
            {
                result = "text/html";
            }
            return result;
        }

        public static string getNormalPathToFile(string filepath)
        {
            return filepath.Replace('\\', '/');
        }

        public static string getDomain(string url)
        {
            return url.Split('/')[1];
        }

        public static string getExternalIp()
        {
            return new WebClient().DownloadString("http://icanhazip.com").Trim();
        }
    }
}
