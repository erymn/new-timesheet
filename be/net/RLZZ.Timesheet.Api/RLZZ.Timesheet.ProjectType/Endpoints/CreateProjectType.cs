using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.ProjectType.Features;
using RLZZ.Timesheet.ProjectType.Model;
using RLZZ.Timesheet.ProjectType.Services;

namespace RLZZ.Timesheet.ProjectType.Endpoints;

public class CreateProjectType(ICommandor commandor)
    : Endpoint<ProjectTypeDto, CreatedProjectTypeResponse>
{
    public override void Configure()
    {
        Post("/api/v1/project-types");
        Policies("AdminPolicy");
    }

    public override async Task HandleAsync(ProjectTypeDto projectTypeDto, CancellationToken ct)
    {
        var query = new CreateProjectTypeCommand(projectTypeDto);
        var projectType = await commandor.SendAsync(query, ct);

        await Send.CreatedAtAsync<GetProjectTypeById>(
            new { ProjectTypeId = projectType.ProjectTypeUniqueId }
            , new CreatedProjectTypeResponse(projectType.ProjectTypeUniqueId)
            , generateAbsoluteUrl: false
            , cancellation: ct);
    }
}

public record CreatedProjectTypeResponse(string ProjectTypeId);