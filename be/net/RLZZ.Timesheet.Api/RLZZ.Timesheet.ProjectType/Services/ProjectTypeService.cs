using Commandor;
using RLZZ.Timesheet.ProjectType.Features;
using RLZZ.Timesheet.ProjectType.Model;
using RLZZ.Timesheet.ProjectType.Repositories;

namespace RLZZ.Timesheet.ProjectType.Services;

public class ProjectTypeService(IProjectTypeRepository projectTypeRepository, ICommandor commandor) : IProjectTypeService
{
    public async Task<List<ProjectTypeDto>> ListProjectTypesAsync(GetAllProjectTypeCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectTypeService>(cancellationToken);
        
        var projectTypes = await projectTypeRepository.ListAllAsync();
        return projectTypes.Select(e => new ProjectTypeDto(
            e.ProjectTypeUniqueId,
            e.Name
        )).ToList();
    }

    public async Task<ProjectTypeDto> GetProjectTypeByIdAsync(GetProjectTypeByIdCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectTypeService>(cancellationToken);
        
        var projectType = await projectTypeRepository.GetByIdAsync(command.Id);
        return new ProjectTypeDto(projectType.ProjectTypeUniqueId, projectType.Name);
    }

    public async Task<ProjectTypeDto> AddProjectTypeAsync(CreateProjectTypeCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectTypeService>(cancellationToken);
        
        Model.ProjectType projectTypeData = new Model.ProjectType(command.ProjectType.Name);
        
        await projectTypeRepository.AddAsync(projectTypeData);
        return new ProjectTypeDto(command.ProjectType.ProjectTypeUniqueId, projectTypeData.Name);
    }

    public async Task<bool> UpdateProjectTypeAsync(UpdateProjectTypeCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectTypeService>(cancellationToken);
        
        Model.ProjectType updatedProjectType = await  projectTypeRepository.GetByIdAsync(command.ProjectType.ProjectTypeUniqueId);
        updatedProjectType.Name = command.ProjectType.Name;
        await projectTypeRepository.UpdateAsync(updatedProjectType);
        
        return true;
    }

    public async Task<bool> DeleteProjectTypeAsync(DeleteProjectTypeCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectTypeService>(cancellationToken);
        
        Model.ProjectType delProjectType = await projectTypeRepository.GetByIdAsync(command.Id);
        delProjectType.UpdateDeletedFlag(true);
        await projectTypeRepository.UpdateAsync(delProjectType);
        return true;
    }
}