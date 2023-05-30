namespace amitChat11.GeneratorModule;

public static class PropertyIndex
{
    
    public const int SYNC_INDEX = 0;
    public const int CHECKSUM_INDEX = SYNC_INDEX+PropertyLength.SYNC;
    public const int DATA_LENGTH_INDEX=CHECKSUM_INDEX+PropertyLength.CHECKSUM ;
    public const int ID_INDEX = DATA_LENGTH_INDEX+PropertyLength.DATA_LENGTH;
    public const int SENDER_ID_INDEX = ID_INDEX+PropertyLength.ID;
    public const int RECEIVER_ID_INDEX = SENDER_ID_INDEX+PropertyLength.SENDER_ID;
    public const int MESSAGE_TYPE_INDEX = RECEIVER_ID_INDEX+PropertyLength.RECEIVER_ID;
    public const int DATA_INDEX =  MESSAGE_TYPE_INDEX+PropertyLength.MESSAGE_TYPE;
}