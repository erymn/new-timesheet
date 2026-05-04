using System.Net;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Model;

namespace RLZZ.Timesheet.User.Endpoints;

public class UpdateUser(ICommandor commandor) : EndpointWithoutRequest<UpdateUserRequest>
{
    public override void Configure()
    {
        Put("/api/v1/users/{id}");
        Policies("AdminPolicy");
    }

    public async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
    {
        if (req.Id != req.UserDto.UserUniqueId)
        {
            await Send.ResponseAsync(new UpdateUserRequest()
            {
                Message = "ID mismatch"
            }, (int)HttpStatusCode.BadRequest, ct);
        }

        var query = new UpdateUserCommand(req.UserDto);
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

public record UpdateUserRequest
{
    [FromRoute] public string Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public UserDto UserDto { get; init; }
    public string Message { get; set; }
}