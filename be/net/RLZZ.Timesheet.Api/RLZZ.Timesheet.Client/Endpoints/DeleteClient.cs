using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Client.Features;

namespace RLZZ.Timesheet.Client.Endpoints;

public class DeleteClient(ICommandor commandor) : Endpoint<DeleteClientRequest>
{
    public override void Configure()
    {
        Delete("/api/v1/clients/{id}");
        
        //TODO: Next harus set Security nya
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteClientRequest req, CancellationToken ct)
    {
        var query = new DeleteClientCommand(req.Id);
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

public record DeleteClientRequest
{
    [FromRoute] public string Id { get; set; }
}