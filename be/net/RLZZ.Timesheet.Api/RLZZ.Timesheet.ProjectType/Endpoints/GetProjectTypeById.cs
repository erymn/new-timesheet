using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.ProjectType.Features;
using RLZZ.Timesheet.ProjectType.Services;

namespace RLZZ.Timesheet.ProjectType.Endpoints;

public class GetProjectTypeById(ICommandor commandor) : Endpoint<GetProjectTypeByIdRequest>
{
    public override void Configure()
    {
        Get("/api/v1/project-types/{id}");
        Policies("UserPolicy");
    }
    
    public override async Task HandleAsync(GetProjectTypeByIdRequest req, CancellationToken ct)
    {
        var query = new GetProjectTypeByIdCommand(req.ProjectTypeId);
        var projectType = await commandor.SendAsync(query, ct);

        if (projectType is null)
        {
            await Send.NotFoundAsync(ct);
        }
        else
        {
            await Send.OkAsync(projectType, ct);
        }
    }
}

public record GetProjectTypeByIdRequest
{
    [FromRoute] public string ProjectTypeId { get; set; }
}