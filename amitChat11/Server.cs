using amitChat11.DataModule;

namespace amitChat11;
using ParserModule;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Text;

public class Server
{
    static void ServerMain()
    {
        using (var responseSocket = new ResponseSocket())
        {
            responseSocket.Bind("tcp://127.0.0.1:5555");

            Console.WriteLine("Server started, waiting for data...");

            while (true)
            {
                byte[] requestBytes = responseSocket.ReceiveFrameBytes();
                Console.WriteLine("Received data: {0}", string.Join(", ", requestBytes));
                
                //IEnumerable<byte> packet = requestBytes.Cast<byte>();?
                IEnumerable<byte> packet = requestBytes;


                MessageBase messageBase = ObjectConvert.ConvertToObject(packet);
                
                // Send the response back to the client
                responseSocket.SendFrame(Encoding.ASCII.GetBytes("Sending completed successfully"));
;
            }
        }
    }
}