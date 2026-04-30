using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Group.Features;
using RLZZ.Timesheet.Group.Services;

namespace RLZZ.Timesheet.Group.Endpoints;

public class GetGroupById(ICommandor commandor) : Endpoint<GetGroupByIdRequest>
{
    public override void Configure()
    {
        Get("/api/v1/groups/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetGroupByIdRequest req, CancellationToken ct)
    {
        var query = new GetGroupByIdCommand(req.GroupId);
        var group = await commandor.SendAsync(query, ct);

        if (group is null)
        {
            await Send.NotFoundAsync(ct);
        }
        else
        {
            await Send.OkAsync(group, ct);
        }
    }
}

public record GetGroupByIdRequest
{
    [FromRoute] public string GroupId { get; set; }
}