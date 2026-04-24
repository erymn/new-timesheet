using Microsoft.EntityFrameworkCore;
using UserModel = RLZZ.Timesheet.User.Model.User;
using UserLoginHistoryModel = RLZZ.Timesheet.User.Model.UserLoginHistory;

namespace RLZZ.Timesheet.User.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users => Set<UserModel>();
    public DbSet<UserLoginHistoryModel> UserLoginHistories => Set<UserLoginHistoryModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserUniqueId).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.Salt).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.IpAddressLock).HasMaxLength(50);
            entity.Property(e => e.SpvId).HasMaxLength(50);
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<UserLoginHistoryModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.LoginDate).IsRequired();
        });
    }
}