using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Group.Features;

namespace RLZZ.Timesheet.Group.Endpoints;

public class DeleteGroup(ICommandor commandor) : Endpoint<DeleteGroupRequest>
{
    public override void Configure()
    {
        Delete("/api/v1/groups/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteGroupRequest req, CancellationToken ct)
    {
        var query = new DeleteGroupCommand(req.Id);
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

public record DeleteGroupRequest
{
    [FromRoute] public string Id { get; set; }
}