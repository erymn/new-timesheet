using Commandor;
using RLZZ.Timesheet.User.Model;

namespace RLZZ.Timesheet.User.Features;

public record LoginCommand(LoginDto Login): IRequest<AuthResponseDto>;
public record RefreshTokenCommand(string AccessToken, string RefreshToken): IRequest<AuthResponseDto>;