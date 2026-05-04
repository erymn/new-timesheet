using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Model;

namespace RLZZ.Timesheet.User.Endpoints;

public class Login(ICommandor commandor)
    : Endpoint<LoginDto>
{
    public override void Configure()
    {
        Post("/api/v1/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginDto loginDto, CancellationToken ct)
    {
        try
        {
            var query = new LoginCommand(loginDto);
            var authResponse = await commandor.SendAsync(query, ct);

            await Send.OkAsync(new
            {
                AccessToken = authResponse.AccessToken,
                RefreshToken = authResponse.RefreshToken,
                Username = authResponse.Username,
                Email = authResponse.Email,
                Roles = authResponse.Roles,
                ExpiresAt = authResponse.ExpiresAt
            }, ct);
        }
        catch (UnauthorizedAccessException ex)
        {
            ThrowError(ex.Message);
        }
    }
}