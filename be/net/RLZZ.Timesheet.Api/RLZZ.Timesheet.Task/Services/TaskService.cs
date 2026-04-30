using SysTask = System.Threading.Tasks;
using Commandor;
using RLZZ.Timesheet.Task.Features;
using RLZZ.Timesheet.Task.Model;
using RLZZ.Timesheet.Task.Repositories;
using TsTaskModel = RLZZ.Timesheet.Task.Model.TsTask;

namespace RLZZ.Timesheet.Task.Services;

public class TaskService(ITsTaskRepository taskRepository, ICommandor commandor) : ITaskService
{
    public async SysTask.Task<List<TsTaskDto>> ListTasksAsync(GetAllTaskCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<ITaskService>(cancellationToken);
        
        var tasks = await taskRepository.ListAllAsync();
        return tasks.Select(e => new TsTaskDto(
            e.ProjectTypeId,
            e.ProjectId,
            e.UserId,
            e.Description,
            e.SubmissionStatus,
            e.SubmitDate,
            e.ApprovalDate,
            e.ApprovalName
        )).ToList();
    }

    public async SysTask.Task<TsTaskDto> GetTaskByIdAsync(GetTaskByIdCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<ITaskService>(cancellationToken);
        
        var task = await taskRepository.GetByIdAsync(command.Id);
        return new TsTaskDto(task.ProjectTypeId, task.ProjectId, task.UserId, task.Description, task.SubmissionStatus, task.SubmitDate, task.ApprovalDate, task.ApprovalName);
    }

    public async SysTask.Task<TsTaskDto> AddTaskAsync(CreateTaskCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<ITaskService>(cancellationToken);
        
        TsTaskModel taskData = new TsTaskModel(command.Task.ProjectTypeId, command.Task.ProjectId, command.Task.UserId, command.Task.Description);
        
        await taskRepository.AddAsync(taskData);
        return new TsTaskDto(taskData.ProjectTypeId, taskData.ProjectId, taskData.UserId, taskData.Description, taskData.SubmissionStatus, taskData.SubmitDate, taskData.ApprovalDate, taskData.ApprovalName);
    }

    public async SysTask.Task<bool> UpdateTaskAsync(UpdateTaskCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<ITaskService>(cancellationToken);
        
        TsTaskModel updatedTask = await  taskRepository.GetByIdAsync(command.Task.Id);
        updatedTask.Description = command.Task.Description;
        updatedTask.SubmissionStatus = command.Task.SubmissionStatus;
        await taskRepository.UpdateAsync(updatedTask);
        
        return true;
    }

    public async SysTask.Task<bool> DeleteTaskAsync(DeleteTaskCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<ITaskService>(cancellationToken);
        
        TsTaskModel delTask = await taskRepository.GetByIdAsync(command.Id);
        delTask.UpdateDeletedFlag(true);
        await taskRepository.UpdateAsync(delTask);
        return true;
    }
}