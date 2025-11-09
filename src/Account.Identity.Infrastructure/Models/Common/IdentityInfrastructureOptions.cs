namespace Account.Identity.Infrastructure.Models.Common;

public class IdentityInfrastructureOptions
{
    public string AuthSecret { get; set; } = string.Empty;
    public string RefreshTokenSecret { get; set; } = string.Empty;
    public int ExpireAccessTokenSeconds { get; set; } = 900;
    public int ExpireRefreshTokenHours { get; set; } = 240;
    public string? ValidAudience { get; init; }
    public string? ValidIssuer { get; init; }
    public bool IsCheckValidAudience { get; init; } = true;
    public bool IsCheckValidIssuer { get; init; } = true;
    public bool IsCheckExpireDate { get; init; } = true;
}
