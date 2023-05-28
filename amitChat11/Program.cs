using amitChat11.DataModule;

namespace amitChat11;
using System;

class Program
{
    static public void Main(String[] args)
    {
        TextMessage a = new TextMessage(MessageType.Text, "hi");
        Console.WriteLine(a.m_Data);
        Console.WriteLine(a.m_SenderId);
        Console.WriteLine("Main Method");
    }
}