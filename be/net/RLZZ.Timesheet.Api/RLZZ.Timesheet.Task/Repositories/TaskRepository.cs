using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Task.Data;

namespace RLZZ.Timesheet.Task.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<Model.TsTask> GetByIdAsync(long id)
    {
        return await _context.Tasks.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.TsTask>> ListAllAsync()
    {
        return await _context.Tasks.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async System.Threading.Tasks.Task AddAsync(Model.TsTask task)
    {
        await _context.Tasks.AddAsync(task);
        await SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task UpdateAsync(Model.TsTask task)
    {
        _context.Tasks.Update(task);
        await SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task DeleteAsync(Model.TsTask task)
    {
        task.UpdateDeletedFlag(true);
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}