using System;

namespace SimpleServer101
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer();
            server.Listen();
        }
    }
}