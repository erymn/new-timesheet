using SysTask = System.Threading.Tasks;
using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Task.Features;
using RLZZ.Timesheet.Task.Model;
using RLZZ.Timesheet.Task.Services;

namespace RLZZ.Timesheet.Task.Endpoints;

public class CreateTask(ICommandor commandor)
    : Endpoint<TsTaskDto, CreatedTaskResponse>
{
    public override void Configure()
    {
        Post("/api/v1/tasks");
        AllowAnonymous();
    }

    public override async SysTask.Task HandleAsync(TsTaskDto taskDto, CancellationToken ct)
    {
        var query = new CreateTaskCommand(taskDto);
        var task = await commandor.SendAsync(query, ct);

        await Send.CreatedAtAsync<GetTaskById>(
            new { TaskId = task.Id }
            , new CreatedTaskResponse(task.Id)
            , generateAbsoluteUrl: false
            , cancellation: ct);
    }
}

public record CreatedTaskResponse(long TaskId);