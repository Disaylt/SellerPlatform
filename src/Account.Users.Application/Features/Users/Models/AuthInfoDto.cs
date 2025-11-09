namespace Account.Users.Application.Features.Users.Models
{
    public record AuthInfoDto
    {
        public required string AccessToken { get; init; }
        public required string RefreshToken {  get; init; }
    }
}
