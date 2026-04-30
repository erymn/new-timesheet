using Commandor;
using RLZZ.Timesheet.Project.Model;

namespace RLZZ.Timesheet.Project.Features;

public record CreateProjectCommand(ProjectDto Project) : IRequest<ProjectDto>;
public record UpdateProjectCommand(ProjectDto Project): IRequest<bool>;
public record DeleteProjectCommand(string Id): IRequest<bool>;
public record GetProjectByIdCommand(string Id) : IRequest<ProjectDto>;
public record GetAllProjectCommand(): IRequest<List<ProjectDto>>;