namespace Account.Identity.Application.Features.Sessions.Models;

public record AuthDataDto
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
}
