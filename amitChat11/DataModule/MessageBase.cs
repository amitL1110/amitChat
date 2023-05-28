namespace amitChat11.DataModule;

public abstract class MessageBase
{
    public Guid m_Id;
    public Guid m_SenderId;
    public Guid m_ReceiverId;
    public MessageType m_Type;

    protected MessageBase(MessageType type)
    {
        m_Id = Guid.NewGuid();
        m_SenderId = Guid.NewGuid();
        m_ReceiverId = Guid.NewGuid();
        m_Type = type;
    }
     
    public Guid MId { get; set; }
    public Guid MSenderId { get; set; }
    public Guid MReceiverId { get; set; }
    public MessageType MType { get; set; }
    
}