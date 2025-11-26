namespace Core.Contracts.Messages.Account.Users;

public record SessionCreatedMessageV1
{
    public required string Id { get; init; }
}
