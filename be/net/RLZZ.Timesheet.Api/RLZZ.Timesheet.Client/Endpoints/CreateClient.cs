using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Client.Features;
using RLZZ.Timesheet.Client.Model;
using RLZZ.Timesheet.Client.Services;

namespace RLZZ.Timesheet.Client.Endpoints;

public class CreateClient(ICommandor commandor)
    : Endpoint<ClientDto, CreatedClientResponse>
{
    public override void Configure()
    {
        Post("/api/v1/clients");
        Policies("AdminPolicy");
    }

    public override async Task HandleAsync(ClientDto clientDto, CancellationToken ct)
    {
        var query = new CreateClientCommand(clientDto);
        var client = await commandor.SendAsync(query, ct);

        await Send.CreatedAtAsync<GetClientById>(
            new { ClientId = client.ClientUniqueId }
            , new CreatedClientResponse(client.ClientUniqueId)
            , generateAbsoluteUrl: false
            , cancellation: ct);
        
        //await Send.OkAsync(new CreatedClientResponse(clientCreated.ClientUniqueId), ct);
    }
}

public record CreatedClientResponse(string ClientId);