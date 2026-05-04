using Commandor;
using RLZZ.Timesheet.Project.Features;
using RLZZ.Timesheet.Project.Model;

namespace RLZZ.Timesheet.Project.Services;

public interface IProjectService : ICommandorService
{
    [QueryHandler]
    Task<List<ProjectDto>> ListProjectsAsync(GetAllProjectCommand command, CancellationToken cancellationToken = default);
    
    [QueryHandler]
    Task<ProjectDto> GetProjectByIdAsync(GetProjectByIdCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<ProjectDto> AddProjectAsync(CreateProjectCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> UpdateProjectAsync(UpdateProjectCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> DeleteProjectAsync(DeleteProjectCommand command, CancellationToken cancellationToken = default);
}