using amitChat11.DataModule;

namespace amitChat11;

public class FactoryPatternDemo
{
    
    public static void Main(String[] args) {
        MessageFactory messageFactory = new MessageFactory();
        MessageBase mes1;
        string filePath="hi.pdf";
        //creating MessageBase object just by the extension of the file path
        mes1 = messageFactory.GetMessage(filePath);


    }
    
}