using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.ProjectType.Features;
using RLZZ.Timesheet.ProjectType.Services;

namespace RLZZ.Timesheet.ProjectType.Endpoints;

public class GetAllProjectType(ICommandor commandor) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/project-types");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllProjectTypeCommand();
        var projectTypes = await commandor.SendAsync(query, ct);
        
        await Send.OkAsync(projectTypes, ct);
    }
}