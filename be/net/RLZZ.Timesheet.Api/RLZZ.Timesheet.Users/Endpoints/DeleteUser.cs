using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.User.Features;

namespace RLZZ.Timesheet.User.Endpoints;

public class DeleteUser(ICommandor commandor) : Endpoint<DeleteUserRequest>
{
    public override void Configure()
    {
        Delete("/api/v1/users/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        var query = new DeleteUserCommand(req.Id);
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

public record DeleteUserRequest
{
    [FromRoute] public string Id { get; set; }
}