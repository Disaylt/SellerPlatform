using Account.Identity.Domain.Seed;

namespace Account.Identity.Application.Services.Abstraction;

public interface ITokenService<T> where T : IAuthInfo
{
    public string Create(T value);
    public T Read(string token);
    public Task<bool> IsValid(string token);
}
