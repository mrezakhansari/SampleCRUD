using Microsoft.EntityFrameworkCore;
using SampleCRUD.Domain;

namespace SampleCRUD.Persistence.DatabaseContext;

public class SampleCRUDDatabaseContext : DbContext
{ 
    public SampleCRUDDatabaseContext(DbContextOptions<SampleCRUDDatabaseContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleCRUDDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entry = base.ChangeTracker.Entries<Product>().FirstOrDefault(c=>c.State == EntityState.Added);
        if (entry != null)
        {
            if (entry is { State : EntityState.Added })
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
