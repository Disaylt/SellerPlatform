using Account.Users.Domain.Entities;

namespace Account.Users.Application.Features.Users.Services.Abstraction
{
    public interface IUserService
    {
        Task<User> FindByLoginAsync(string login);
        Task<User> FindByEmailAsync(string email);
        Task<User> CreateAsync(string login, string email, string password);
        Task<bool> VerifyPassword(string userNameOrEmail, string password);
        Task DeleteAsync(string id);
    }
}
