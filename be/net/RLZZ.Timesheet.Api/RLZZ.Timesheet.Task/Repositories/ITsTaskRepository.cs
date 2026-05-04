using SysTask = System.Threading.Tasks;
using TsTaskModel = RLZZ.Timesheet.Task.Model.TsTask;

namespace RLZZ.Timesheet.Task.Repositories;

public interface ITsTaskRepository
{
    SysTask.Task<TsTaskModel> GetByIdAsync(long id);
    SysTask.Task<List<TsTaskModel>> ListAllAsync();
    SysTask.Task AddAsync(TsTaskModel task);
    SysTask.Task UpdateAsync(TsTaskModel task);
    SysTask.Task DeleteAsync(TsTaskModel task);
    SysTask.Task<int> SaveChangesAsync();
}