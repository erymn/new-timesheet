using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.SystemParameter.Data;

namespace RLZZ.Timesheet.SystemParameter.Repositories;

public class SysParamRepository : ISysParamRepository
{
    private readonly SystemParameterDbContext _context;

    public SysParamRepository(SystemParameterDbContext context)
    {
        _context = context;
    }

    public async Task<Model.SysParam> GetByIdAsync(int id)
    {
        return await _context.SysParams.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.SysParam>> ListAllAsync()
    {
        return await _context.SysParams.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.SysParam sysParam)
    {
        await _context.SysParams.AddAsync(sysParam);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.SysParam sysParam)
    {
        _context.SysParams.Update(sysParam);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.SysParam sysParam)
    {
        sysParam.UpdateDeletedFlag(true);
        _context.SysParams.Update(sysParam);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}