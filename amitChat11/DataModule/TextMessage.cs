namespace amitChat11.DataModule;
using System;
using System.Text;
public class TextMessage : MessageBase
{
    public byte[] m_Data;
    
    public TextMessage(MessageType type, string data) : base(type)
    {
        try
        {
            m_Data = Encoding.ASCII.GetBytes(data);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    public string MData { get; set; }

}