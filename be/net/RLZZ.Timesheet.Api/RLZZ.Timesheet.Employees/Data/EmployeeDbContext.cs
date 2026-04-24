using Microsoft.EntityFrameworkCore;
using EmployeeModel = RLZZ.Timesheet.Employees.Model.Employee;

namespace RLZZ.Timesheet.Employees.Data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }

    public DbSet<EmployeeModel> Employees => Set<EmployeeModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.EmployeeUniqueId).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}