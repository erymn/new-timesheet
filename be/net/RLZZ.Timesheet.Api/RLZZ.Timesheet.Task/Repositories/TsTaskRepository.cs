using SysTask = System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Task.Data;
using TsTaskModel = RLZZ.Timesheet.Task.Model.TsTask;

namespace RLZZ.Timesheet.Task.Repositories;

public class TsTaskRepository : ITsTaskRepository
{
    private readonly TaskDbContext _context;

    public TsTaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async SysTask.Task<TsTaskModel> GetByIdAsync(long id)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async SysTask.Task<List<TsTaskModel>> ListAllAsync()
    {
        return await _context.Tasks.Where(t => t.IsDeleted == false).ToListAsync();
    }

    public async SysTask.Task AddAsync(TsTaskModel task)
    {
        await _context.Tasks.AddAsync(task);
        await SaveChangesAsync();
    }

    public async SysTask.Task UpdateAsync(TsTaskModel task)
    {
        _context.Tasks.Update(task);
        await SaveChangesAsync();
    }

    public async SysTask.Task DeleteAsync(TsTaskModel task)
    {
        task.UpdateDeletedFlag(true);
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async SysTask.Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}