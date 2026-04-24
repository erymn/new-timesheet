using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.AppsMenu.Data;

namespace RLZZ.Timesheet.AppsMenu.Repositories;

public class AppsMenuRepository : IAppsMenuRepository
{
    private readonly AppsMenuDbContext _context;

    public AppsMenuRepository(AppsMenuDbContext context)
    {
        _context = context;
    }

    public async Task<Model.AppsMenu> GetByIdAsync(int id)
    {
        return await _context.AppsMenus.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.AppsMenu>> ListAllAsync()
    {
        return await _context.AppsMenus.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.AppsMenu appsMenu)
    {
        await _context.AppsMenus.AddAsync(appsMenu);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.AppsMenu appsMenu)
    {
        _context.AppsMenus.Update(appsMenu);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.AppsMenu appsMenu)
    {
        appsMenu.UpdateDeletedFlag(true);
        _context.AppsMenus.Update(appsMenu);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}