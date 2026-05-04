using SysTask = System.Threading.Tasks;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Task.Features;

namespace RLZZ.Timesheet.Task.Endpoints;

public class DeleteTask(ICommandor commandor) : Endpoint<DeleteTaskRequest>
{
    public override void Configure()
    {
        Delete("/api/v1/tasks/{id}");
        Policies("UserPolicy");
    }

    public override async SysTask.Task HandleAsync(DeleteTaskRequest req, CancellationToken ct)
    {
        var query = new DeleteTaskCommand(req.Id);
        var command = await commandor.SendAsync(query, ct);
        
        if (command)
        {
            await Send.NoContentAsync(ct);
        }
        else
        {
            await Send.NotFoundAsync(ct);
        }
    }
}

public record DeleteTaskRequest
{
    [FromRoute] public long Id { get; set; }
}