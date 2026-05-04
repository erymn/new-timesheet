using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RLZZ.Timesheet.Project.Repositories;
using RLZZ.Timesheet.Project.Services;

namespace RLZZ.Timesheet.Project.Extension;

public static class ProjectServiceExtension
{
    public static IServiceCollection AddProjectService(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCommandor();
        
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        
        return services;
    }
}