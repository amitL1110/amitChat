namespace amitChat11.GeneratorModule;
using DataModule;
using System;
using System.Text;
using System.Collections.Generic;


public class PacketConvert
{
    public static IEnumerable<byte> ConvertToPacket(MessageBase message)
    {
        int length;
        
        List<byte> packet = new List<byte>();
        List<byte> proPacket = new List<byte>();
        proPacket = PropertiesPacket(message);
        
        //add the Sync
        packet.AddRange(BitConverter.GetBytes(0x65));
        
        packet.AddRange(ChecksumModule.Checksum(proPacket));
        
        if (message is TextMessage)
        {
            length = (Encoding.ASCII.GetBytes(((TextMessage)message).MData)).Length;
            packet.AddRange(BitConverter.GetBytes(length));
        }
        else if (message is ImageMessage)
        {
            length = (Encoding.ASCII.GetBytes(((ImageMessage)message).MData)).Length;
            packet.AddRange(BitConverter.GetBytes(length));

        }
        else if (message is AudioFile)
        {
            length = (Encoding.ASCII.GetBytes(((AudioFile)message).MData)).Length;
            packet.AddRange(BitConverter.GetBytes(length));
        }
        else
        {
            length = (Encoding.ASCII.GetBytes(((PdfFile)message).MData)).Length;
            packet.AddRange(BitConverter.GetBytes(length));
        }
        
        //add properties packet
        packet.AddRange(proPacket);
        
        //add tail
        packet.AddRange(BitConverter.GetBytes(0xB1));
        
        return packet;
    }

    private static List<byte> PropertiesPacket(MessageBase message)
    {
        List<byte> pPacket = new List<byte>();
        pPacket.AddRange(AddNormal(message));
        
        if (message is TextMessage)
        {
            pPacket.AddRange(Encoding.ASCII.GetBytes(((TextMessage)message).MData));
        }
        else if(message is ImageMessage)
        {
            pPacket.AddRange(Encoding.ASCII.GetBytes(((ImageMessage)message).MData));
            pPacket.AddRange(BitConverter.GetBytes((int)((ImageMessage)message).MExtension));
        }
        else if(message is FileMessage)
        {
            if (message is AudioFile)
            {
                pPacket.AddRange(Encoding.ASCII.GetBytes(((AudioFile)message).MData));
            }
            else
            {
                pPacket.AddRange(Encoding.ASCII.GetBytes(((PdfFile)message).MData));
            }

            pPacket.AddRange(BitConverter.GetBytes((int)((FileMessage)message).MFileType));
            pPacket.AddRange(BitConverter.GetBytes((int)((FileMessage)message).MExtension));
        }

        return pPacket;
    }
    
    private static IEnumerable<byte> AddNormal(MessageBase mess)
    {
        List<byte> add = new List<byte>();
        add.AddRange((mess.MId).ToByteArray());
        add.AddRange((mess.MSenderId).ToByteArray());
        add.AddRange((mess.MReceiverId).ToByteArray());
        add.AddRange(BitConverter.GetBytes((int)mess.MType));
        return add;
    }
}