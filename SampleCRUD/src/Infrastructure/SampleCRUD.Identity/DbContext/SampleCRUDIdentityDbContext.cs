using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleCRUD.Identity.Models;

namespace SampleCRUD.Identity.DbContext;

public class SampleCRUDIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public SampleCRUDIdentityDbContext(DbContextOptions<SampleCRUDIdentityDbContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(SampleCRUDIdentityDbContext).Assembly);
    }
}
