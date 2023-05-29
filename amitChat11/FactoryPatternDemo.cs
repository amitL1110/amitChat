using amitChat11.DataModule;

namespace amitChat11;

public class FactoryPatternDemo
{
    
    public static void Main(String[] args) {
        MessageFactory messageFactory = new MessageFactory();
        MessageBase mes1;
        string filePath="hi.pdf";
        //creating MessageBase object just by the extension of the file path
        if (filePath.Contains((Extensions.Ogg).ToString()))
        {
            mes1 = messageFactory.GetMessage(MessageType.File,Extensions.Ogg,filePath,FileType.Audio);
        }
        else if (filePath.Contains((Extensions.Mp3).ToString()))
        {
            mes1 = messageFactory.GetMessage(MessageType.File,Extensions.Mp3,filePath,FileType.Audio);
        }
        else if (filePath.Contains((Extensions.Pdf).ToString()))
        {
            mes1 = messageFactory.GetMessage(MessageType.File,Extensions.Pdf,filePath,FileType.Pdf);
        }
        else if (filePath.Contains((Extensions.Jpeg).ToString()))
        {
            mes1 = messageFactory.GetMessage(MessageType.Image,Extensions.Jpeg,filePath);
        }
        else if (filePath.Contains((Extensions.Png).ToString()))
        {
            mes1 = messageFactory.GetMessage(MessageType.Image,Extensions.Png,filePath);
        }
        else if (filePath.Contains((Extensions.Bmp).ToString()))
        {
            mes1 = messageFactory.GetMessage(MessageType.Image,Extensions.Bmp,filePath);
        }
        else
        {
            mes1 = messageFactory.GetMessage(MessageType.Text, filePath);
        }
        

    }
    
}