using Core.Contracts.Config.SolutionConfig.ExternalServices.Account.Identity;
using Core.Contracts.Config.SolutionConfig.ExternalServices.Account.Session;
using Core.Contracts.Config.SolutionConfig.ExternalServices.Account.User;

namespace Core.Contracts.Config.SolutionConfig.ExternalServices.Account;

public class AccountModel
{
    public IdentityModel Identity { get; set; } = new();
    public UserModel User { get; set; } = new();
    public SessionModel Session { get; set; } = new();
}
