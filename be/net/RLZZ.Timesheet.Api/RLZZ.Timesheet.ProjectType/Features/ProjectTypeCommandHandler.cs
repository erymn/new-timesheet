using Commandor;
using RLZZ.Timesheet.ProjectType.Model;

namespace RLZZ.Timesheet.ProjectType.Features;

public record CreateProjectTypeCommand(ProjectTypeDto ProjectType) : IRequest<ProjectTypeDto>;
public record UpdateProjectTypeCommand(ProjectTypeDto ProjectType): IRequest<bool>;
public record DeleteProjectTypeCommand(string Id): IRequest<bool>;
public record GetProjectTypeByIdCommand(string Id) : IRequest<ProjectTypeDto>;
public record GetAllProjectTypeCommand(): IRequest<List<ProjectTypeDto>>;