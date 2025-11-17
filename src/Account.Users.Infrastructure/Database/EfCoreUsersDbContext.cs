using Account.Users.Infrastructure.Features.Sessions.Models;
using Account.Users.Infrastructure.Features.Users.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Account.Users.Infrastructure.Database;

public class EfCoreUsersDbContext : IdentityDbContext<AppIdentityUser>
{
    public EfCoreUsersDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<SessionEntity> Sessions { get; set; } = null!;

}
