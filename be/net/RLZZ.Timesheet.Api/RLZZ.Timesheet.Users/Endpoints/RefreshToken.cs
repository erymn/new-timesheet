using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.User.Features;

namespace RLZZ.Timesheet.User.Endpoints;

public class RefreshToken(ICommandor commandor)
    : Endpoint<RefreshTokenRequest>
{
    public override void Configure()
    {
        Post("/api/v1/auth/refresh-token");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RefreshTokenRequest req, CancellationToken ct)
    {
        try
        {
            var query = new RefreshTokenCommand(req.AccessToken, req.RefreshToken);
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

public record RefreshTokenRequest
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}