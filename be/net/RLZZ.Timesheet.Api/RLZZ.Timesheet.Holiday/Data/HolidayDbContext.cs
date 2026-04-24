using Microsoft.EntityFrameworkCore;
using HolidayModel = RLZZ.Timesheet.Holiday.Model.Holiday;

namespace RLZZ.Timesheet.Holiday.Data;

public class HolidayDbContext : DbContext
{
    public HolidayDbContext(DbContextOptions<HolidayDbContext> options) : base(options)
    {
    }

    public DbSet<HolidayModel> Holidays => Set<HolidayModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HolidayModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.HolidayUniqueId).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            entity.Property(e => e.HolidayDay).IsRequired();
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}