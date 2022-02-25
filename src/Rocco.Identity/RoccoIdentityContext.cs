using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rocco.Identity.Models;

namespace Rocco.Identity;

public class RoccoIdentityContext : IdentityDbContext<ApplicationUser>
{
    public RoccoIdentityContext(DbContextOptions<RoccoIdentityContext> options) : base(options)
    {

    }
}
