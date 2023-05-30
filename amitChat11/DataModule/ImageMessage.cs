namespace amitChat11.DataModule;

internal class ImageMessage : MessageBase
{
    private byte[] m_Data;
    private Extensions m_Extension;
    
    public ImageMessage(MessageType type, string filePath, Extensions extension) : base(type)
    {
        m_Extension = extension;
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
    public Extensions MExtension{ get; set; }
    
}