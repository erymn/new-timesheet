using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Group.Features;
using RLZZ.Timesheet.Group.Model;
using RLZZ.Timesheet.Group.Services;

namespace RLZZ.Timesheet.Group.Endpoints;

public class CreateGroup(ICommandor commandor)
    : Endpoint<GroupDto, CreatedGroupResponse>
{
    public override void Configure()
    {
        Post("/api/v1/groups");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GroupDto groupDto, CancellationToken ct)
    {
        var query = new CreateGroupCommand(groupDto);
        var group = await commandor.SendAsync(query, ct);

        await Send.CreatedAtAsync<GetGroupById>(
            new { GroupId = group.GroupId }
            , new CreatedGroupResponse(group.GroupId)
            , generateAbsoluteUrl: false
            , cancellation: ct);
    }
}

public record CreatedGroupResponse(string GroupId);