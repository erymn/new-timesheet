using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RLZZ.Timesheet.Task.Repositories;
using RLZZ.Timesheet.Task.Services;

namespace RLZZ.Timesheet.Task.Extension;

public static class TaskServiceExtension
{
    public static IServiceCollection AddTaskService(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCommandor();
        
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<ITsTaskRepository, TsTaskRepository>();
        
        return services;
    }
}