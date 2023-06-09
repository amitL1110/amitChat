﻿namespace amitChat11.DataModule;
using System;
using System.Text;
public class TextMessage : MessageBase
{
    private byte[] m_Data;
    
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

    public TextMessage(MessageType type, byte[] data, Guid id, Guid senderId, Guid receiverId) : base(type, id, senderId, receiverId)
    {
        m_Data = data;
    }
    public string MData { get; set; }

}