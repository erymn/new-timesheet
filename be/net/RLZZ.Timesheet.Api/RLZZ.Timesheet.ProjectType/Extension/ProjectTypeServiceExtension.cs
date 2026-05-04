using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RLZZ.Timesheet.ProjectType.Repositories;
using RLZZ.Timesheet.ProjectType.Services;

namespace RLZZ.Timesheet.ProjectType.Extension;

public static class ProjectTypeServiceExtension
{
    public static IServiceCollection AddProjectTypeService(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCommandor();
        
        services.AddScoped<IProjectTypeService, ProjectTypeService>();
        services.AddScoped<IProjectTypeRepository, ProjectTypeRepository>();
        
        return services;
    }
}