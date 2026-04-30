using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Group.Features;
using RLZZ.Timesheet.Group.Services;

namespace RLZZ.Timesheet.Group.Endpoints;

public class GetAllGroup(ICommandor commandor) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/groups");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllGroupCommand();
        var groups = await commandor.SendAsync(query, ct);
        
        await Send.OkAsync(groups, ct);
    }
}