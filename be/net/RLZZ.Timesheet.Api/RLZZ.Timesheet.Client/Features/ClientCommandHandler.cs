using Commandor;
using RLZZ.Timesheet.Client.Model;

namespace RLZZ.Timesheet.Client.Features;

//Command
public record CreateClientCommand(ClientDto Client) : IRequest<ClientDto>;
public record UpdateClientCommand(ClientDto Client): IRequest<bool>;
public record DeleteClientCommand(string Id): IRequest<bool>;
public record GetClientByIdCommand(string Id) : IRequest<ClientDto>;
public record GetAllClientCommand(): IRequest<List<ClientDto>>;