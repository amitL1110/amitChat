using amitChat11.DataModule;
using amitChat11.GeneratorModule;

using NetMQ;
using NetMQ.Sockets;

namespace amitChat11;

public class Client
{
    
     static void Main(String[] args) {
        
        MessageFactory messageFactory = new MessageFactory();
        MessageBase mes1;
        
        using (var requestSocket = new RequestSocket())
        {
            requestSocket.Connect("tcp://127.0.0.1:5555");

            while (true)
            {
                string filePath = Console.ReadLine();
                
                if (filePath == "exit")
                    break;
                
                //creating MessageBase object just by the extension of the file path

                mes1 = messageFactory.GetMessage(filePath);
                
                IEnumerable<byte> collection = PacketConvert.ConvertToPacket(mes1);
                

                // Convert the data to an array of bytes
                byte[] dataBytes = collection.ToArray();

                // Send the data to the server
                requestSocket.SendFrame(dataBytes);

                // Receive the response from the server
                byte[] responseBytes = requestSocket.ReceiveFrameBytes();
                Console.WriteLine("Received response: {0}", string.Join(", ", responseBytes));
            }
        }


    }
    
}