namespace Account.Users.Domain.Entities;

public class Session
{
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public DateTime LastUse { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public DateTime Updated { get; set; } = DateTime.UtcNow;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string? CorrelationId { get; set; }
}
