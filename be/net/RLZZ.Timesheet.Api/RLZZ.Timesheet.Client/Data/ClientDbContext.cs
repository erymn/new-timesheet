using Microsoft.EntityFrameworkCore;
using ClientModel = RLZZ.Timesheet.Client.Model.Client;

namespace RLZZ.Timesheet.Client.Data;

public class ClientDbContext : DbContext
{
    public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
    {
    }

    public DbSet<ClientModel> Clients => Set<ClientModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ClientUniqueId).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}