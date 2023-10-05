using Microsoft.EntityFrameworkCore;
using Shipment.Core.Common;
using Shipment.Core.Entities;

namespace Shipment.Infrastructure.Data;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure CountryId in State entity as a foreign key to Country entity
        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(x=>x.Id);
        });
        
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(x=>x.Id);
        });
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}