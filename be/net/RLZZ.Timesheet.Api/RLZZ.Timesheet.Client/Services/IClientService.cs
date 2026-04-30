using Commandor;
using RLZZ.Timesheet.Client.Features;
using RLZZ.Timesheet.Client.Model;

namespace RLZZ.Timesheet.Client.Services;

public interface IClientService : ICommandorService
{
    //Use Lightweight MediatR Replacement
    [QueryHandler]
    Task<List<ClientDto>> ListClientsAsync(GetAllClientCommand command, CancellationToken cancellationToken = default);
    
    [QueryHandler]
    Task<ClientDto> GetClientByIdAsync(GetClientByIdCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<ClientDto> AddClientAsync(CreateClientCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> UpdateClientAsync(UpdateClientCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> DeleteClientAsync(DeleteClientCommand command, CancellationToken cancellationToken = default);
    
    //// USED OLD FASHION WAY
    // Task<List<ClientDto>> ListClientsAsync();
    // Task<ClientDto> GetClientByIdAsync(string id);
    // Task<ClientDto> AddClientAsync(ClientDto client);
    // Task<bool> UpdateClientAsync(ClientDto reqClientDto);
    // Task<bool> DeleteClientAsync(string id);
}


