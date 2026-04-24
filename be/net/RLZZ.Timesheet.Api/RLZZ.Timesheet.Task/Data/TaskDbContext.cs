using Microsoft.EntityFrameworkCore;
using TsTaskModel = RLZZ.Timesheet.Task.Model.TsTask;
using TsSubmissionModel = RLZZ.Timesheet.Task.Model.TsSubmission;
using TsSubmissionDetailModel = RLZZ.Timesheet.Task.Model.TsSubmissionDetail;

namespace RLZZ.Timesheet.Task.Data;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<TsTaskModel> Tasks => Set<TsTaskModel>();
    public DbSet<TsSubmissionModel> Submissions => Set<TsSubmissionModel>();
    public DbSet<TsSubmissionDetailModel> SubmissionDetails => Set<TsSubmissionDetailModel>();

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
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<TsSubmissionModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SubmitterMail).HasMaxLength(200).IsRequired();
            entity.Property(e => e.ApproverName).HasMaxLength(100);
            
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<TsSubmissionDetailModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProjectTypeId).HasMaxLength(50);
            entity.Property(e => e.ProjectId).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
        });
    }
}