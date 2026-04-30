using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Client.Features;
using RLZZ.Timesheet.Client.Services;

namespace RLZZ.Timesheet.Client.Endpoints;

public class GetAllClient(ICommandor commandor) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/api/v1/clients");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllClientCommand();
        var clients = await commandor.SendAsync(query, ct);
        
        await Send.OkAsync(clients, ct);
    }
}