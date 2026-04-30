using Commandor;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Model;

namespace RLZZ.Timesheet.User.Services;

public interface IUserService : ICommandorService
{
    [QueryHandler]
    Task<List<UserDto>> ListUsersAsync(GetAllUserCommand command, CancellationToken cancellationToken = default);
    
    [QueryHandler]
    Task<UserDto> GetUserByIdAsync(GetUserByIdCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<UserDto> AddUserAsync(CreateUserCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> UpdateUserAsync(UpdateUserCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> DeleteUserAsync(DeleteUserCommand command, CancellationToken cancellationToken = default);
}