using Microsoft.EntityFrameworkCore;
using TsTaskModel = RLZZ.Timesheet.Task.Model.TsTask;

namespace RLZZ.Timesheet.Task.Data;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<TsTaskModel> Tasks => Set<TsTaskModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TsTaskModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProjectTypeId).HasMaxLength(50);
            entity.Property(e => e.ProjectId).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ApprovalName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}