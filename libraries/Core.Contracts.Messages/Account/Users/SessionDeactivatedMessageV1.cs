namespace Core.Contracts.Messages.Account.Users;

public record SessionDeactivatedMessageV1
{
    public required string Id { get; init; }
}
