using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Project.Features;
using RLZZ.Timesheet.Project.Services;

namespace RLZZ.Timesheet.Project.Endpoints;

public class GetProjectById(ICommandor commandor) : Endpoint<GetProjectByIdRequest>
{
    public override void Configure()
    {
        Get("/api/v1/projects/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetProjectByIdRequest req, CancellationToken ct)
    {
        var query = new GetProjectByIdCommand(req.ProjectId);
        var project = await commandor.SendAsync(query, ct);

        if (project is null)
        {
            await Send.NotFoundAsync(ct);
        }
        else
        {
            await Send.OkAsync(project, ct);
        }
    }
}

public record GetProjectByIdRequest
{
    [FromRoute] public string ProjectId { get; set; }
}