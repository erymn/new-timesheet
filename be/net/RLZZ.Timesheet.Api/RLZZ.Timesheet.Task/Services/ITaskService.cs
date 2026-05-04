using SysTask = System.Threading.Tasks;
using Commandor;
using RLZZ.Timesheet.Task.Features;
using RLZZ.Timesheet.Task.Model;

namespace RLZZ.Timesheet.Task.Services;

public interface ITaskService : ICommandorService
{
    [QueryHandler]
    SysTask.Task<List<TsTaskDto>> ListTasksAsync(GetAllTaskCommand command, CancellationToken cancellationToken = default);
    
    [QueryHandler]
    SysTask.Task<TsTaskDto> GetTaskByIdAsync(GetTaskByIdCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    SysTask.Task<TsTaskDto> AddTaskAsync(CreateTaskCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    SysTask.Task<bool> UpdateTaskAsync(UpdateTaskCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    SysTask.Task<bool> DeleteTaskAsync(DeleteTaskCommand command, CancellationToken cancellationToken = default);
}