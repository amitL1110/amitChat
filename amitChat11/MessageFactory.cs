using amitChat11.DataModule;

namespace amitChat11;

public class MessageFactory
{
    //use getShape method to get object of type shape 
    public MessageBase GetMessage(MessageType mesType, string data)
    {
        return new TextMessage(mesType, data);
    }

    public MessageBase GetMessage(MessageType mesType,Extensions extension, string filePath)
    {

        return new ImageMessage(mesType,filePath,extension);
    }
    
    public MessageBase GetMessage(MessageType mesType,Extensions extension, string filePath, FileType fileType)
    {
        if (fileType == FileType.Audio)
        {
            return new AudioFile(mesType, extension, fileType, filePath);
        }

        return new PdfFile(mesType, extension, fileType, filePath);
    }
}