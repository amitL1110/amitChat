namespace amitChat11.DataModule;

public class AudioFile: FileMessage
{
    private byte[] m_Data;
    
    public AudioFile(MessageType type, Extensions extension, FileType fileType, string filePath) : base(type,extension,fileType)
    {
        try
        {
            m_Data = File.ReadAllBytes(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    public AudioFile(MessageType type, Extensions extension, FileType fileType, byte[] data, Guid id, Guid senderId, Guid receiverId) : base(type,extension,fileType,id,senderId,receiverId)
    {
        m_Data = data;
    }
    
    public string MData { get; set; }

}