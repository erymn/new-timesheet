using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RLZZ.Timesheet.Client.Repositories;
using RLZZ.Timesheet.Client.Services;

namespace RLZZ.Timesheet.Client.Extension;

public static class ClientServiceExtension
{
    public static IServiceCollection AddClientService(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCommandor();
        
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IClientRepository, ClientRepository>();
        
        return services;
    }
}