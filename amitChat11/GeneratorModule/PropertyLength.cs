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
    public int m_FileType = 0;
    public int m_Extension = 0;
    
    public int m_Data;

    public PropertyLength(IEnumerable<byte> packet,MessageBase message)
    {
        byte[] arr = packet.Skip(PropertyIndex.DATA_LENGTH_INDEX).Take(DATA_LENGTH).ToArray();
        m_Data = BitConverter.ToInt32(arr, 0);

        if (!(message is TextMessage))
        {
            m_Extension = 4;

            if (message is FileMessage)
            {
                m_FileType = 4;
            }
        }
        
        
    }
    
    
}