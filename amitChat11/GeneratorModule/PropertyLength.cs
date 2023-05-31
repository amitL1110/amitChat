using amitChat11.DataModule;

namespace amitChat11.GeneratorModule;

public class PropertyLength
{
    public const int SYNC = 1;
    public const int CHECKSUM = 8;
    public const int DATA_LENGTH=4 ;
    public const int ID = 16;
    public const int SENDER_ID = 16;
    public const int RECEIVER_ID = 16;
    public const int MESSAGE_TYPE = 4;
    public const int TAIL = 4;
    
    //if exist
    public readonly int m_FileType = 0;
    public readonly int m_Extension = 0;
    
    public readonly int m_Data;

    public PropertyLength(IEnumerable<byte> packet)
    {
        
        byte[] messageTypeBytes =  packet.Skip(PropertyIndex.MESSAGE_TYPE_INDEX).Take(MESSAGE_TYPE).ToArray();
        byte[] dataLengthBytes = packet.Skip(PropertyIndex.DATA_LENGTH_INDEX).Take(DATA_LENGTH).ToArray();
        m_Data = BitConverter.ToInt32(dataLengthBytes, 0);

        if (messageTypeBytes != (BitConverter.GetBytes((int)(MessageType.Text))))
        {
            m_Extension = 4;

            if (messageTypeBytes == (BitConverter.GetBytes((int)(MessageType.File))))
            {
                m_FileType = 4;
            }
        }
        
        
        
    }
    
    
}