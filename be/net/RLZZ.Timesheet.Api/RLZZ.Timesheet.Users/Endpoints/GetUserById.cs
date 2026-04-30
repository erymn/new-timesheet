using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Services;

namespace RLZZ.Timesheet.User.Endpoints;

public class GetUserById(ICommandor commandor) : Endpoint<GetUserByIdRequest>
{
    public override void Configure()
    {
        Get("/api/v1/users/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetUserByIdRequest req, CancellationToken ct)
    {
        var query = new GetUserByIdCommand(req.UserId);
        var user = await commandor.SendAsync(query, ct);

        if (user is null)
        {
            await Send.NotFoundAsync(ct);
        }
        else
        {
            await Send.OkAsync(user, ct);
        }
    }
}

public record GetUserByIdRequest
{
    [FromRoute] public string UserId { get; set; }
}