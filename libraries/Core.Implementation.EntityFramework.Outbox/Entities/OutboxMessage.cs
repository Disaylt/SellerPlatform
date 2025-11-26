namespace Core.Implementation.EntityFramework.Outbox.Entities;

public class OutboxMessage
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Type { get; private set; }
    public string Payload { get; private set; }
    public int Atempts { get; private set; }
    public DateTime Created { get; private set; } = DateTime.UtcNow;
    
    protected OutboxMessage()
    {
        Type = default!;
        Payload = default!;
    }

    public OutboxMessage(string  type, string payload)
    {
        Type = type;
        Payload = payload;
    }
}
