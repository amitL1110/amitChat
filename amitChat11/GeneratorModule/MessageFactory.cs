using amitChat11.DataModule;

namespace amitChat11;

public class MessageFactory
{
    //use getShape method to get object of type shape 
    public MessageBase GetMessage(string filePath)
    {
        if (filePath.Contains(((Extensions.Ogg).ToString()).ToLower()))
        {
            return new AudioFile(MessageType.File, Extensions.Ogg, FileType.Audio, filePath);
        }
        else if (filePath.Contains((Extensions.Mp3).ToString()))
        {
            return new AudioFile(MessageType.File, Extensions.Mp3, FileType.Audio, filePath);
        }
        else if (filePath.Contains((Extensions.Pdf).ToString()))
        {
            return new PdfFile(MessageType.File, Extensions.Pdf, FileType.Pdf, filePath);

        }
        else if (filePath.Contains((Extensions.Jpeg).ToString()))
        {
            return new ImageMessage(MessageType.Image,filePath,Extensions.Jpeg);
        }
        else if (filePath.Contains((Extensions.Png).ToString()))
        {
            return new ImageMessage(MessageType.Image,filePath,Extensions.Png);
        }
        else if (filePath.Contains((Extensions.Bmp).ToString()))
        {
            return new ImageMessage(MessageType.Image,filePath,Extensions.Bmp);
        }
        else
        {
            return new TextMessage(MessageType.Text, filePath);
        }
    }
    
}