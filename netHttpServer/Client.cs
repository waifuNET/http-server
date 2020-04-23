using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace netHttpServer
{
    class Client
    {
        static string DefaultFilePath = Classes.getStartupPath + "/www";
        public static async Task ClientHandler(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string FilePath = Classes.getNormalPathToFile(DefaultFilePath + request.RawUrl);
            byte[] ResultResponse = default;

            if (!File.Exists(FilePath))
            {
                FilePath = Classes.getNormalPathToFile(DefaultFilePath + "/system/errors/error404.html");
            }
            ResultResponse = File.ReadAllBytes(FilePath);

            string ContentType;
            string Extension = Path.GetExtension(request.RawUrl);

            ContentType = Classes.getHTTPContentType(Extension);

            response.ContentType = ContentType;
            response.ContentEncoding = Encoding.UTF8;
            response.ContentLength64 = ResultResponse.Length;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusDescription = "OK";
            response.ProtocolVersion = new Version("1.1");

            Stream output = response.OutputStream;
            output.Write(ResultResponse, 0, ResultResponse.Length);

            output.Close();

            await Task.Delay(100);
        }
    }
}
