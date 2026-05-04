using System.Net;
using SysTask = System.Threading.Tasks;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Task.Features;
using RLZZ.Timesheet.Task.Model;

namespace RLZZ.Timesheet.Task.Endpoints;

public class UpdateTask(ICommandor commandor) : EndpointWithoutRequest<UpdateTaskRequest>
{
    public override void Configure()
    {
        Put("/api/v1/tasks/{id}");
        Policies("UserPolicy");
    }

    public async SysTask.Task HandleAsync(UpdateTaskRequest req, CancellationToken ct)
    {
        if (req.Id != req.TaskDto.Id)
        {
            await Send.ResponseAsync(new UpdateTaskRequest()
            {
                Message = "ID mismatch"
            }, (int)HttpStatusCode.BadRequest, ct);
        }

        var query = new UpdateTaskCommand(req.TaskDto);
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

public record UpdateTaskRequest
{
    [FromRoute] public long Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public TsTaskDto TaskDto { get; init; }
    public string Message { get; set; }
}