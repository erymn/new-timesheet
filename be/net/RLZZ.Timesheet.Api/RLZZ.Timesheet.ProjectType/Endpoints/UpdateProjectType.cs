using System.Net;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.ProjectType.Features;
using RLZZ.Timesheet.ProjectType.Model;

namespace RLZZ.Timesheet.ProjectType.Endpoints;

public class UpdateProjectType(ICommandor commandor) : EndpointWithoutRequest<UpdateProjectTypeRequest>
{
    public override void Configure()
    {
        Put("/api/v1/project-types/{id}");
        Policies("AdminPolicy");
    }

    public async Task HandleAsync(UpdateProjectTypeRequest req, CancellationToken ct)
    {
        if (req.Id != req.ProjectTypeDto.ProjectTypeUniqueId)
        {
            await Send.ResponseAsync(new UpdateProjectTypeRequest()
            {
                Message = "ID mismatch"
            }, (int)HttpStatusCode.BadRequest, ct);
        }

        var query = new UpdateProjectTypeCommand(req.ProjectTypeDto);
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

public record UpdateProjectTypeRequest
{
    [FromRoute] public string Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public ProjectTypeDto ProjectTypeDto { get; init; }
    public string Message { get; set; }
}