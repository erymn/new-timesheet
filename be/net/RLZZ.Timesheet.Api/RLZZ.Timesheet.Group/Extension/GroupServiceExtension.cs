using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RLZZ.Timesheet.Group.Repositories;
using RLZZ.Timesheet.Group.Services;

namespace RLZZ.Timesheet.Group.Extension;

public static class GroupServiceExtension
{
    public static IServiceCollection AddGroupService(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCommandor();
        
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        
        return services;
    }
}