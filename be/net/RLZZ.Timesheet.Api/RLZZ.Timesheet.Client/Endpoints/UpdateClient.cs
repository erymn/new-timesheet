using System.Net;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Client.Features;
using RLZZ.Timesheet.Client.Model;

namespace RLZZ.Timesheet.Client.Endpoints;

public class UpdateClient(ICommandor commandor) : EndpointWithoutRequest<UpdateClientRequest>
{
    public override void Configure()
    {
        Put("/api/v1/clients/{id}");

        //TODO: Next harus set Security nya
        AllowAnonymous();
    }

    public async Task HandleAsync(UpdateClientRequest req, CancellationToken ct)
    {
        if (req.Id != req.ClientDto.ClientUniqueId)
        {
            await Send.ResponseAsync(new UpdateClientRequest()
            {
                Message = "ID mismatch"
            }, (int)HttpStatusCode.BadRequest, ct);
        }

        var query = new UpdateClientCommand(req.ClientDto);
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

public record UpdateClientRequest
{
    [FromRoute] public string Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public ClientDto ClientDto { get; init; }
    public string Message { get; set; }
}