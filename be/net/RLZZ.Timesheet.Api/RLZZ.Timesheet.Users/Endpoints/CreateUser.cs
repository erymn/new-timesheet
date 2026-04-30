using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Model;
using RLZZ.Timesheet.User.Services;

namespace RLZZ.Timesheet.User.Endpoints;

public class CreateUser(ICommandor commandor)
    : Endpoint<UserDto, CreatedUserResponse>
{
    public override void Configure()
    {
        Post("/api/v1/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UserDto userDto, CancellationToken ct)
    {
        var query = new CreateUserCommand(userDto);
        var user = await commandor.SendAsync(query, ct);

        await Send.CreatedAtAsync<GetUserById>(
            new { UserId = user.UserUniqueId }
            , new CreatedUserResponse(user.UserUniqueId)
            , generateAbsoluteUrl: false
            , cancellation: ct);
    }
}

public record CreatedUserResponse(string UserId);