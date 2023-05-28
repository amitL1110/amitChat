namespace amitChat11.DataModule;

public class TextMessage : MessageBase
{
    public byte[] m_Data;
    
    public TextMessage(MessageType type, string filePath) : base(type)
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
    
    public string MData { get; set; }

}