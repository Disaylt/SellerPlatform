namespace Account.Users.Domain.Entities;

public class User
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
}
