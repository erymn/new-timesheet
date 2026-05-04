using System.Net;
using Commandor;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using RLZZ.Timesheet.Project.Features;
using RLZZ.Timesheet.Project.Model;

namespace RLZZ.Timesheet.Project.Endpoints;

public class UpdateProject(ICommandor commandor) : EndpointWithoutRequest<UpdateProjectRequest>
{
    public override void Configure()
    {
        Put("/api/v1/projects/{id}");
        Policies("AdminPolicy");
    }

    public async Task HandleAsync(UpdateProjectRequest req, CancellationToken ct)
    {
        if (req.Id != req.ProjectDto.ProjectUniqueId)
        {
            await Send.ResponseAsync(new UpdateProjectRequest()
            {
                Message = "ID mismatch"
            }, (int)HttpStatusCode.BadRequest, ct);
        }

        var query = new UpdateProjectCommand(req.ProjectDto);
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

public record UpdateProjectRequest
{
    [FromRoute] public string Id { get; init; }
    [Microsoft.AspNetCore.Mvc.FromBody] public ProjectDto ProjectDto { get; init; }
    public string Message { get; set; }
}