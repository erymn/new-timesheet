using Commandor;
using FastEndpoints;
using RLZZ.Timesheet.Project.Features;
using RLZZ.Timesheet.Project.Model;
using RLZZ.Timesheet.Project.Services;

namespace RLZZ.Timesheet.Project.Endpoints;

public class CreateProject(ICommandor commandor)
    : Endpoint<ProjectDto, CreatedProjectResponse>
{
    public override void Configure()
    {
        Post("/api/v1/projects");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ProjectDto projectDto, CancellationToken ct)
    {
        var query = new CreateProjectCommand(projectDto);
        var project = await commandor.SendAsync(query, ct);

        await Send.CreatedAtAsync<GetProjectById>(
            new { ProjectId = project.ProjectUniqueId }
            , new CreatedProjectResponse(project.ProjectUniqueId)
            , generateAbsoluteUrl: false
            , cancellation: ct);
    }
}

public record CreatedProjectResponse(string ProjectId);