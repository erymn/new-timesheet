using Microsoft.EntityFrameworkCore;
using SysParamModel = RLZZ.Timesheet.SystemParameter.Model.SysParam;

namespace RLZZ.Timesheet.SystemParameter.Data;

public class SystemParameterDbContext : DbContext
{
    public SystemParameterDbContext(DbContextOptions<SystemParameterDbContext> options) : base(options)
    {
    }

    public DbSet<SysParamModel> SysParams => Set<SysParamModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SysParamModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.SysParamUniqueId).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}