using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Services;

namespace RLZZ.Timesheet.User.Endpoints;

public class GetAllUser(ICommandor commandor) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/users");
        Policies("AdminPolicy");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllUserCommand();
        var users = await commandor.SendAsync(query, ct);
        
        await Send.OkAsync(users, ct);
    }
}