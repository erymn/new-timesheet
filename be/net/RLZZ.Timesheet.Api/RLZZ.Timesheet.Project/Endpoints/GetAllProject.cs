using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Project.Features;
using RLZZ.Timesheet.Project.Services;

namespace RLZZ.Timesheet.Project.Endpoints;

public class GetAllProject(ICommandor commandor) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/projects");
        Policies("UserPolicy");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllProjectCommand();
        var projects = await commandor.SendAsync(query, ct);
        
        await Send.OkAsync(projects, ct);
    }
}