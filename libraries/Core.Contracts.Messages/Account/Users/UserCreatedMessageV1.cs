namespace Core.Contracts.Messages.Account.Users;

public record UserCreatedMessageV1
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
}
