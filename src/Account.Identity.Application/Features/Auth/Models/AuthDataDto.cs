namespace Account.Identity.Application.Features.Auth.Models;

public record AuthDataDto
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
}
