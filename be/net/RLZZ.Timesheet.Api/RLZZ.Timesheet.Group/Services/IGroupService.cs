using Commandor;
using RLZZ.Timesheet.Group.Features;
using RLZZ.Timesheet.Group.Model;

namespace RLZZ.Timesheet.Group.Services;

public interface IGroupService : ICommandorService
{
    [QueryHandler]
    Task<List<GroupDto>> ListGroupsAsync(GetAllGroupCommand command, CancellationToken cancellationToken = default);
    
    [QueryHandler]
    Task<GroupDto> GetGroupByIdAsync(GetGroupByIdCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<GroupDto> AddGroupAsync(CreateGroupCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> UpdateGroupAsync(UpdateGroupCommand command, CancellationToken cancellationToken = default);
    
    [CommandHandler]
    Task<bool> DeleteGroupAsync(DeleteGroupCommand command, CancellationToken cancellationToken = default);
}