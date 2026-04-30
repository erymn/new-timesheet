using Commandor;
using RLZZ.Timesheet.Project.Features;
using RLZZ.Timesheet.Project.Model;
using RLZZ.Timesheet.Project.Repositories;

namespace RLZZ.Timesheet.Project.Services;

public class ProjectService(IProjectRepository projectRepository, ICommandor commandor) : IProjectService
{
    public async Task<List<ProjectDto>> ListProjectsAsync(GetAllProjectCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectService>(cancellationToken);
        
        var projects = await projectRepository.ListAllAsync();
        return projects.Select(e => new ProjectDto(
            e.ProjectUniqueId,
            e.Code,
            e.Name,
            e.ClientId,
            e.Mandays,
            e.IsBillable
        )).ToList();
    }

    public async Task<ProjectDto> GetProjectByIdAsync(GetProjectByIdCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectService>(cancellationToken);
        
        var project = await projectRepository.GetByIdAsync(command.Id);
        return new ProjectDto(project.ProjectUniqueId, project.Code, project.Name, project.ClientId, project.Mandays, project.IsBillable);
    }

    public async Task<ProjectDto> AddProjectAsync(CreateProjectCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectService>(cancellationToken);
        
        Model.Project projectData = new Model.Project(command.Project.Code, command.Project.Name, command.Project.ClientId, command.Project.IsBillable, command.Project.Mandays);
        
        await projectRepository.AddAsync(projectData);
        return new ProjectDto(command.Project.ProjectUniqueId, projectData.Code, projectData.Name, projectData.ClientId, projectData.Mandays, projectData.IsBillable);
    }

    public async Task<bool> UpdateProjectAsync(UpdateProjectCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectService>(cancellationToken);
        
        Model.Project updatedProject = await  projectRepository.GetByIdAsync(command.Project.ProjectUniqueId);
        updatedProject.Name = command.Project.Name;
        updatedProject.Mandays = command.Project.Mandays;
        updatedProject.IsBillable = command.Project.IsBillable;
        await projectRepository.UpdateAsync(updatedProject);
        
        return true;
    }

    public async Task<bool> DeleteProjectAsync(DeleteProjectCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IProjectService>(cancellationToken);
        
        Model.Project delProject = await projectRepository.GetByIdAsync(command.Id);
        delProject.UpdateDeletedFlag(true);
        await projectRepository.UpdateAsync(delProject);
        return true;
    }
}