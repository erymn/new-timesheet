using Microsoft.EntityFrameworkCore;
using ProjectTypeModel = RLZZ.Timesheet.ProjectType.Model.ProjectType;

namespace RLZZ.Timesheet.ProjectType.Data;

public class ProjectTypeDbContext : DbContext
{
    public ProjectTypeDbContext(DbContextOptions<ProjectTypeDbContext> options) : base(options)
    {
    }

    public DbSet<ProjectTypeModel> ProjectTypes => Set<ProjectTypeModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectTypeModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProjectTypeUniqueId).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}