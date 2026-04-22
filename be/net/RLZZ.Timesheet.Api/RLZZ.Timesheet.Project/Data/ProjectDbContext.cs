using Microsoft.EntityFrameworkCore;
using ProjectModel = RLZZ.Timesheet.Project.Model.Project;

namespace RLZZ.Timesheet.Project.Data;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    }

    public DbSet<ProjectModel> Projects => Set<ProjectModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProjectUniqueId).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.ClientId).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}