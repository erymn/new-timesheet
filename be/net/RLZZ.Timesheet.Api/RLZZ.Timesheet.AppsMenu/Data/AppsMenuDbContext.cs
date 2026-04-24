using Microsoft.EntityFrameworkCore;
using AppsMenuModel = RLZZ.Timesheet.AppsMenu.Model.AppsMenu;
using MenuParamModel = RLZZ.Timesheet.AppsMenu.Model.MenuParam;

namespace RLZZ.Timesheet.AppsMenu.Data;

public class AppsMenuDbContext : DbContext
{
    public AppsMenuDbContext(DbContextOptions<AppsMenuDbContext> options) : base(options)
    {
    }

    public DbSet<AppsMenuModel> AppsMenus => Set<AppsMenuModel>();
    public DbSet<MenuParamModel> MenuParams => Set<MenuParamModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppsMenuModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.GroupId).HasMaxLength(50);
            entity.Property(e => e.MenuName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Route).HasMaxLength(200);
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<MenuParamModel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MenuName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.MenuRoute).HasMaxLength(200).IsRequired();
            
            entity.Property(e => e.IsActive);
            entity.Property(e => e.IsDeleted);
            entity.Property(e => e.CreatedDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
        });
    }
}