namespace Account.Users.Application.Features.Users.Models;

public class UserDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime Created { get; set; }
}
