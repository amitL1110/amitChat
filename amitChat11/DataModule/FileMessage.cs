namespace amitChat11.DataModule;

public abstract class FileMessage : MessageBase
{
    
    protected Extensions m_Extension;
    protected FileType m_FileType;

    protected FileMessage(MessageType type, Extensions extension, FileType fileType) : base(type)
    {
        m_Extension = extension;
        m_FileType = fileType;
    }
    
    public Extensions MExtension { get; set; }
    public FileType MFileType { get; set; }

}