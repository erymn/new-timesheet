using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Project.Features;

namespace RLZZ.Timesheet.Project.Endpoints;

public class DeleteProject(ICommandor commandor) : Endpoint<DeleteProjectRequest>
{
    public override void Configure()
    {
        Delete("/api/v1/projects/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteProjectRequest req, CancellationToken ct)
    {
        var query = new DeleteProjectCommand(req.Id);
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

public record DeleteProjectRequest
{
    [FromRoute] public string Id { get; set; }
}