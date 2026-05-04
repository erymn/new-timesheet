using SysTask = System.Threading.Tasks;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Task.Features;
using RLZZ.Timesheet.Task.Services;

namespace RLZZ.Timesheet.Task.Endpoints;

public class GetTaskById(ICommandor commandor) : Endpoint<GetTaskByIdRequest>
{
    public override void Configure()
    {
        Get("/api/v1/tasks/{id}");
        Policies("UserPolicy");
    }
    
    public override async SysTask.Task HandleAsync(GetTaskByIdRequest req, CancellationToken ct)
    {
        var query = new GetTaskByIdCommand(req.TaskId);
        var task = await commandor.SendAsync(query, ct);

        if (task is null)
        {
            await Send.NotFoundAsync(ct);
        }
        else
        {
            await Send.OkAsync(task, ct);
        }
    }
}

public record GetTaskByIdRequest
{
    [FromRoute] public long TaskId { get; set; }
}