using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RLZZ.Timesheet.User.Repositories;
using RLZZ.Timesheet.User.Services;

namespace RLZZ.Timesheet.User.Extension;

public static class UserServiceExtension
{
    public static IServiceCollection AddUserService(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCommandor();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}