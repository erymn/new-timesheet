using Microsoft.EntityFrameworkCore;
using GroupModel = RLZZ.Timesheet.Group.Model.Group;

namespace RLZZ.Timesheet.Group.Data;

public class GroupDbContext : DbContext
{
    public GroupDbContext(DbContextOptions<GroupDbContext> options) : base(options)
    {
    }

    public DbSet<GroupModel> Groups => Set<GroupModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.GroupUniqueId).HasMaxLength(100);
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
