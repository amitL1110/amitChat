namespace amitChat11.DataModule;

public abstract class MessageBase
{
    protected Guid m_Id;
    protected Guid m_SenderId;
    protected Guid m_ReceiverId;
    protected MessageType m_Type;

    protected MessageBase(MessageType type)
    {
        m_Id = Guid.NewGuid();
        m_SenderId = Guid.NewGuid();
        m_ReceiverId = Guid.NewGuid();
        m_Type = type;
    }
    
    protected MessageBase(MessageType type, Guid id,Guid senderId,Guid receiverId)
    {
        m_Id = id;
        m_SenderId =senderId;
        m_ReceiverId = receiverId;
        m_Type = type;
    }
     
    public Guid MId { get; set; }
    public Guid MSenderId { get; set; }
    public Guid MReceiverId { get; set; }
    public MessageType MType { get; set; }
    
}