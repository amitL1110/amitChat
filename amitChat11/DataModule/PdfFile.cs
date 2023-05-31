namespace amitChat11.DataModule;

public class PdfFile : FileMessage 
{
    private byte[] m_Data;
    
    public PdfFile(MessageType type, Extensions extension, FileType fileType, string filePath) : base(type,extension,fileType)
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
    
    public PdfFile(MessageType type, Extensions extension, FileType fileType, byte[] data, Guid id, Guid senderId, Guid receiverId) : base(type,extension,fileType,id,senderId,receiverId)
    {
        m_Data = data;
    }
    
    public string MData { get; set; }
}