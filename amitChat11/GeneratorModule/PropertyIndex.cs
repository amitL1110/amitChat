namespace amitChat11.GeneratorModule;

public class PropertyIndex
{
    
    public const int SYNC_INDEX = 0;
    public const int CHECKSUM_INDEX = SYNC_INDEX+PropertyLength.SYNC;
    public const int DATA_LENGTH_INDEX=CHECKSUM_INDEX+PropertyLength.CHECKSUM ;
    public const int ID_INDEX = DATA_LENGTH_INDEX+PropertyLength.DATA_LENGTH;
    public const int SENDER_ID_INDEX = ID_INDEX+PropertyLength.ID;
    public const int RECEIVER_ID_INDEX = SENDER_ID_INDEX+PropertyLength.SENDER_ID;
    public const int MESSAGE_TYPE_INDEX = RECEIVER_ID_INDEX+PropertyLength.RECEIVER_ID;
    public const int DATA_INDEX =  MESSAGE_TYPE_INDEX+PropertyLength.MESSAGE_TYPE;

    public readonly int m_FileTypeIndex;
    public readonly int m_ExtensionIndex;
    public readonly int m_TailIndex;
    
    public PropertyIndex(PropertyLength propertyLength)
    {
        if ((propertyLength.m_FileType!=0)&(propertyLength.m_Extension!=0))
        {
            m_FileTypeIndex = DATA_INDEX + propertyLength.m_Data;
            m_ExtensionIndex = m_FileTypeIndex + propertyLength.m_FileType;
            m_TailIndex = m_ExtensionIndex + propertyLength.m_Extension;
        }
        else if(propertyLength.m_Extension!=0)
        {
            m_ExtensionIndex = DATA_INDEX + propertyLength.m_Data;
            m_TailIndex = m_ExtensionIndex + propertyLength.m_Extension;
        }
        else
        {
            m_TailIndex = DATA_INDEX + propertyLength.m_Data;
        }
    }
    
}