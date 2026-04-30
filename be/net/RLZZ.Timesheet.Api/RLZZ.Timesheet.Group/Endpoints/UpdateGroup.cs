using System.Net;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Group.Features;
using RLZZ.Timesheet.Group.Model;

namespace RLZZ.Timesheet.Group.Endpoints;

public class UpdateGroup(ICommandor commandor) : EndpointWithoutRequest<UpdateGroupRequest>
{
    public override void Configure()
    {
        Put("/api/v1/groups/{id}");
        AllowAnonymous();
    }

    public async Task HandleAsync(UpdateGroupRequest req, CancellationToken ct)
    {
        if (req.Id != req.GroupDto.GroupId)
        {
            await Send.ResponseAsync(new UpdateGroupRequest()
            {
                Message = "ID mismatch"
            }, (int)HttpStatusCode.BadRequest, ct);
        }

        var query = new UpdateGroupCommand(req.GroupDto);
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

public record UpdateGroupRequest
{
    [FromRoute] public string Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public GroupDto GroupDto { get; init; }
    public string Message { get; set; }
}