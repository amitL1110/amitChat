using amitChat11.DataModule;
using amitChat11.GeneratorModule;

namespace amitChat11.ParserModule;

public class ObjectConvert
{

    public static MessageBase ConvertToObject(IEnumerable<byte> packet)
    {
        
        PropertyLength propertyLength = new PropertyLength(packet);
        PropertyIndex propertyIndex = new PropertyIndex(propertyLength);
        bool boolSync=(BitConverter.GetBytes(0x65) == packet.Skip(PropertyIndex.SYNC_INDEX).Take(PropertyLength.SYNC).ToArray());
        bool boolTail=(BitConverter.GetBytes(0xB1) == packet.Skip(propertyIndex.m_TailIndex).Take(PropertyLength.TAIL).ToArray());
        bool boolChecksum=((packet.Skip(PropertyIndex.CHECKSUM_INDEX).Take(PropertyLength.CHECKSUM))==ChecksumModule.Checksum( (packet.Skip(PropertyIndex.ID_INDEX).Take(propertyIndex.m_TailIndex-PropertyIndex.ID_INDEX)).ToList()));
        
        if (boolSync&&boolTail&&boolChecksum)
        {
            byte[] idbyteArray = (packet.Skip(PropertyIndex.ID_INDEX).Take(PropertyLength.ID)).ToArray(); 
            Guid guidId = new Guid(idbyteArray);
            
            byte[] senderIdbyteArray = (packet.Skip(PropertyIndex.SENDER_ID_INDEX).Take(PropertyLength.SENDER_ID)).ToArray(); 
            Guid guidSenderId = new Guid(senderIdbyteArray);
            
            byte[] receiverIdbyteArray = (packet.Skip(PropertyIndex.RECEIVER_ID_INDEX).Take(PropertyLength.RECEIVER_ID)).ToArray(); 
            Guid guidReceiverId = new Guid(receiverIdbyteArray);
            
            byte[] messageTypeByteArray = (packet.Skip(PropertyIndex.MESSAGE_TYPE_INDEX).Take(PropertyLength.MESSAGE_TYPE)).ToArray(); 
            MessageType messageType = (MessageType)Enum.Parse(typeof(MessageType), messageTypeByteArray[0].ToString());

            byte[] data = (packet.Skip(PropertyIndex.DATA_INDEX).Take(propertyLength.m_Data)).ToArray();

            
            if(messageType != MessageType.Text)
            {
                byte[] extensionByteArray = (packet.Skip(propertyIndex.m_ExtensionIndex).Take(propertyLength.m_Extension)).ToArray(); 
                Extensions extension = (Extensions)Enum.Parse(typeof(Extensions), extensionByteArray[0].ToString());
                if (messageType == MessageType.File)
                {
                    byte[] fileTypeByteArray = (packet.Skip(propertyIndex.m_FileTypeIndex).Take(propertyLength.m_FileType)).ToArray(); 
                    FileType fileType = (FileType)Enum.Parse(typeof(FileType), fileTypeByteArray[0].ToString());

                    if (fileType == FileType.Audio)
                    {
                        return new AudioFile(messageType, extension, fileType, data, guidId, guidSenderId, guidReceiverId);
                    }
                    else
                    {
                        return new PdfFile(messageType, extension, fileType, data, guidId, guidSenderId, guidReceiverId);
                    }
                }
                else
                {
                    return new ImageMessage(messageType, data, extension, guidId, guidSenderId, guidReceiverId);
                }
            }
            else
            {
                return new TextMessage(messageType, data, guidId, guidSenderId, guidReceiverId);
            }
        }
        Console.WriteLine("Not validated");
        return null;

    }
}