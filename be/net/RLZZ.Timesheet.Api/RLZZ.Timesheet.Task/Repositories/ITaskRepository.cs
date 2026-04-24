namespace RLZZ.Timesheet.Task.Repositories;

public interface ITaskRepository
{
    Task<Model.TsTask> GetByIdAsync(long id);
    Task<List<Model.TsTask>> ListAllAsync();
    System.Threading.Tasks.Task AddAsync(Model.TsTask task);
    System.Threading.Tasks.Task UpdateAsync(Model.TsTask task);
    System.Threading.Tasks.Task DeleteAsync(Model.TsTask task);
    Task<int> SaveChangesAsync();
}