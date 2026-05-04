using System.Security.Claims;
using Commandor;
using RLZZ.Timesheet.Securities;
using RLZZ.Timesheet.User.Features;
using RLZZ.Timesheet.User.Model;
using RLZZ.Timesheet.User.Repositories;

namespace RLZZ.Timesheet.User.Services;

public class UserService(IUserRepository userRepository, ICommandor commandor, IJwtService jwtService) : IUserService
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

    public async Task<AuthResponseDto> LoginAsync(LoginCommand command, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByUsernameAsync(command.Login.Username);
        
        if (user == null || !user.VerifyPassword(command.Login.Password))
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }

        if (!user.IsActive || user.IsDeleted)
        {
            throw new UnauthorizedAccessException("User account is disabled");
        }

        var roles = user.Roles.Count > 0 ? user.Roles : new List<string> { Roles.Employee };
        var accessToken = jwtService.GenerateAccessToken(user.Id, user.Username, user.Email, roles);
        var refreshToken = jwtService.GenerateRefreshToken();

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Username = user.Username,
            Email = user.Email,
            Roles = roles,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenCommand command, CancellationToken cancellationToken = default)
    {
        var principal = jwtService.GetPrincipalFromExpiredToken(command.AccessToken);
        var userId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        var username = principal.FindFirst(ClaimTypes.Name)?.Value ?? "";
        var email = principal.FindFirst(ClaimTypes.Email)?.Value ?? "";
        var roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

        if (roles.Count == 0)
        {
            roles = new List<string> { Roles.Employee };
        }

        var user = await userRepository.GetByIdAsync(userId.ToString());
        if (user == null || !user.IsActive || user.IsDeleted)
        {
            throw new UnauthorizedAccessException("Invalid user");
        }

        var newAccessToken = jwtService.GenerateAccessToken(userId, username, email, roles);
        var newRefreshToken = jwtService.GenerateRefreshToken();

        return new AuthResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            Username = username,
            Email = email,
            Roles = roles,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }
}