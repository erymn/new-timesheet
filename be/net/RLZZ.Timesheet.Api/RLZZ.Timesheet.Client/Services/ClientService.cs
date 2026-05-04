using Commandor;
using RLZZ.Timesheet.Client.Features;
using RLZZ.Timesheet.Client.Model;
using RLZZ.Timesheet.Client.Repositories;

namespace RLZZ.Timesheet.Client.Services;

public class ClientService(IClientRepository clientRepository, ICommandor commandor) : IClientService
{
    public async Task<List<ClientDto>> ListClientsAsync(GetAllClientCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IClientService>(cancellationToken);
        
        var clients = await clientRepository.ListAllAsync();
        return clients.Select(e => new ClientDto(
            e.ClientUniqueId,
            e.Name
        )).ToList();
    }

    public async Task<ClientDto> GetClientByIdAsync(GetClientByIdCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IClientService>(cancellationToken);
        
        var client = await clientRepository.GetByIdAsync(command.Id);
        return new ClientDto(client.ClientUniqueId, client.Name);
    }

    public async Task<ClientDto> AddClientAsync(CreateClientCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IClientService>(cancellationToken);
        
        Model.Client clientData = new Model.Client(command.Client.Name);
        
        await clientRepository.AddAsync(clientData);
        return new ClientDto(command.Client.ClientUniqueId, clientData.Name);
    }

    public async Task<bool> UpdateClientAsync(UpdateClientCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IClientService>(cancellationToken);
        
        Model.Client updatedClient = await  clientRepository.GetByIdAsync(command.Client.ClientUniqueId);
        updatedClient.Name = command.Client.Name;
        await clientRepository.UpdateAsync(updatedClient);
        
        return true;
    }

    public async Task<bool> DeleteClientAsync(DeleteClientCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IClientService>(cancellationToken);
        
        Model.Client delClient = await clientRepository.GetByIdAsync(command.Id);
        delClient.UpdateDeletedFlag(true);
        await clientRepository.UpdateAsync(delClient);
        return true;
    }
    
    //// USE OLD FASHION WAY
    // private readonly IClientRepository _clientRepository;
    //
    // public ClientService(IClientRepository clientRepository)
    // {
    //     _clientRepository = clientRepository;
    // }
    //
    // public async Task<List<ClientDto>> ListClientsAsync()
    // {
    //     var clients = await _clientRepository.ListAllAsync();
    //     return clients.Select(e => new ClientDto(
    //         e.ClientUniqueId,
    //         e.Name
    //     )).ToList();
    // }
    //
    // public async Task<ClientDto> GetClientByIdAsync(string id)
    // {
    //     var client = await _clientRepository.GetByIdAsync(id);
    //     return new ClientDto(client.ClientUniqueId, client.Name);
    // }
    //
    // public async Task<ClientDto> AddClientAsync(ClientDto client)
    // {
    //     Model.Client clientData = new Model.Client(client.Name);
    //     
    //     await _clientRepository.AddAsync(clientData);
    //     return new ClientDto(client.ClientUniqueId, clientData.Name);
    // }
    //
    // public async Task<bool> UpdateClientAsync(ClientDto reqClientDto)
    // {
    //     Model.Client updatedClient = await  _clientRepository.GetByIdAsync(reqClientDto.ClientUniqueId);
    //     updatedClient.Name = reqClientDto.Name;
    //     await _clientRepository.UpdateAsync(updatedClient);
    //
    //     return true;
    // }
    //
    // public async Task<bool> DeleteClientAsync(string id)
    // {
    //     Model.Client delClient = await _clientRepository.GetByIdAsync(id);
    //     delClient.UpdateDeletedFlag(true);
    //     await _clientRepository.UpdateAsync(delClient);
    //     return true;
    // }
    
}