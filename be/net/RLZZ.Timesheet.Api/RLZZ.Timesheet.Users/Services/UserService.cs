using Commandor;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Model;
using RLZZ.Timesheet.User.Repositories;

namespace RLZZ.Timesheet.User.Services;

public class UserService(IUserRepository userRepository, ICommandor commandor) : IUserService
{
    public async Task<List<UserDto>> ListUsersAsync(GetAllUserCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IUserService>(cancellationToken);
        
        var users = await userRepository.ListAllAsync();
        return users.Select(e => new UserDto(
            e.UserUniqueId,
            e.Username,
            e.Email,
            e.SpvId,
            e.IsForceResetPassword
        )).ToList();
    }

    public async Task<UserDto> GetUserByIdAsync(GetUserByIdCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IUserService>(cancellationToken);
        
        var user = await userRepository.GetByIdAsync(command.Id);
        return new UserDto(user.UserUniqueId, user.Username, user.Email, user.SpvId, user.IsForceResetPassword);
    }

    public async Task<UserDto> AddUserAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IUserService>(cancellationToken);
        
        Model.User userData = new Model.User(command.User.Username, "defaultPassword", Guid.NewGuid().ToString(), command.User.Email, command.User.IsForceResetPassword, command.User.SpvId);
        
        await userRepository.AddAsync(userData);
        return new UserDto(command.User.UserUniqueId, userData.Username, userData.Email, userData.SpvId, userData.IsForceResetPassword);
    }

    public async Task<bool> UpdateUserAsync(UpdateUserCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IUserService>(cancellationToken);
        
        Model.User updatedUser = await  userRepository.GetByIdAsync(command.User.UserUniqueId);
        updatedUser.Email = command.User.Email;
        updatedUser.SpvId = command.User.SpvId;
        await userRepository.UpdateAsync(updatedUser);
        
        return true;
    }

    public async Task<bool> DeleteUserAsync(DeleteUserCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IUserService>(cancellationToken);
        
        Model.User delUser = await userRepository.GetByIdAsync(command.Id);
        delUser.UpdateDeletedFlag(true);
        await userRepository.UpdateAsync(delUser);
        return true;
    }
}