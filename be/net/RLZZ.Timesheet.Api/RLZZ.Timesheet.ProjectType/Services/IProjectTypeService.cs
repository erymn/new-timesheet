using Commandor;
using RLZZ.Timesheet.ProjectType.Features;
using RLZZ.Timesheet.ProjectType.Model;

namespace RLZZ.Timesheet.ProjectType.Services;

public interface IProjectTypeService : ICommandorService
{
    [QueryHandler]
    Task<List<ProjectTypeDto>> ListProjectTypesAsync(GetAllProjectTypeCommand command, CancellationToken cancellationToken = default);
    
    [QueryHandler]
    Task<ProjectTypeDto> GetProjectTypeByIdAsync(GetProjectTypeByIdCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<ProjectTypeDto> AddProjectTypeAsync(CreateProjectTypeCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> UpdateProjectTypeAsync(UpdateProjectTypeCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> DeleteProjectTypeAsync(DeleteProjectTypeCommand command, CancellationToken cancellationToken = default);
}