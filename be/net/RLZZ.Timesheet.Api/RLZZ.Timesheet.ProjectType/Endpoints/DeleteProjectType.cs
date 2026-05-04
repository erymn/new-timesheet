using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.ProjectType.Features;

namespace RLZZ.Timesheet.ProjectType.Endpoints;

public class DeleteProjectType(ICommandor commandor) : Endpoint<DeleteProjectTypeRequest>
{
    public override void Configure()
    {
        Delete("/api/v1/project-types/{id}");
        Policies("AdminPolicy");
    }

    public override async Task HandleAsync(DeleteProjectTypeRequest req, CancellationToken ct)
    {
        var query = new DeleteProjectTypeCommand(req.Id);
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

public record DeleteProjectTypeRequest
{
    [FromRoute] public string Id { get; set; }
}