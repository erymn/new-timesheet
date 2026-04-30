using Commandor;
using RLZZ.Timesheet.Group.Model;

namespace RLZZ.Timesheet.Group.Features;

public record CreateGroupCommand(GroupDto Group) : IRequest<GroupDto>;
public record UpdateGroupCommand(GroupDto Group): IRequest<bool>;
public record DeleteGroupCommand(string Id): IRequest<bool>;
public record GetGroupByIdCommand(string Id) : IRequest<GroupDto>;
public record GetAllGroupCommand(): IRequest<List<GroupDto>>;