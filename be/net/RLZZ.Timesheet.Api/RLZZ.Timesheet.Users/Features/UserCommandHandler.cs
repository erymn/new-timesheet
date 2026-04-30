using Commandor;
using RLZZ.Timesheet.User.Model;

namespace RLZZ.Timesheet.User.Features;

public record CreateUserCommand(UserDto User) : IRequest<UserDto>;
public record UpdateUserCommand(UserDto User): IRequest<bool>;
public record DeleteUserCommand(string Id): IRequest<bool>;
public record GetUserByIdCommand(string Id) : IRequest<UserDto>;
public record GetAllUserCommand(): IRequest<List<UserDto>>;