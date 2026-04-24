using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.AppsMenu.Data;

namespace RLZZ.Timesheet.AppsMenu.Repositories;

public class MenuParamRepository : IMenuParamRepository
{
    private readonly AppsMenuDbContext _context;

    public MenuParamRepository(AppsMenuDbContext context)
    {
        _context = context;
    }

    public async Task<Model.MenuParam> GetByIdAsync(int id)
    {
        return await _context.MenuParams.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.MenuParam>> ListAllAsync()
    {
        return await _context.MenuParams.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.MenuParam menuParam)
    {
        await _context.MenuParams.AddAsync(menuParam);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.MenuParam menuParam)
    {
        _context.MenuParams.Update(menuParam);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.MenuParam menuParam)
    {
        menuParam.UpdateDeletedFlag(true);
        _context.MenuParams.Update(menuParam);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}