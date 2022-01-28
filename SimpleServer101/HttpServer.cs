using System.Net.Sockets;
using System.Net;

namespace SimpleServer101
{
    public class HttpServer
    {
        void GetClientData(TcpClient client)
        {
            // Buffer for reading data
            byte[] bytes = new byte[256];
            string data = "";

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();

            int i;

            // Loop to receive all the data sent by the client.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine($"Received: {data}");

                string response = "Server says Hi!";

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine($"Sent: {response}");
            }

            // Shutdown and end connection
            client.Close();
        }

        public void Listen()
        {
            bool is_active = true;
            IPAddress localhost = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(localhost, 1234);
            listener.Start();
            Console.WriteLine("Server is ready ...");

            while (is_active)
            {
                TcpClient client = listener.AcceptTcpClient();

                if (client != null)
                {
                    Console.WriteLine("A client has connected");
                    GetClientData(client);
                }

                Thread.Sleep(1);
            }
        }
    }
}
