using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Client.Features;
using RLZZ.Timesheet.Client.Services;

namespace RLZZ.Timesheet.Client.Endpoints;

public class GetClientById(ICommandor commandor) : Endpoint<GetClientByIdRequest>
{
    public override void Configure()
    {
        Get("/api/v1/clients/{id}");
        Policies("UserPolicy");
    }
    
    public override async Task HandleAsync(GetClientByIdRequest req, CancellationToken ct)
    {
        var query = new GetClientByIdCommand(req.ClientId);
        var client = await commandor.GetAsync(query, ct);

        if (client is null)
        {
            await Send.NotFoundAsync(ct);
        }
        else
        {
            await Send.OkAsync(client, ct);
        }
    }
}

public record GetClientByIdRequest
{
    [FromRoute] public string ClientId { get; set; }
}