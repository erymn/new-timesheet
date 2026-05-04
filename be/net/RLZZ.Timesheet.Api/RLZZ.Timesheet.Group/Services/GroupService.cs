using Commandor;
using RLZZ.Timesheet.Group.Features;
using RLZZ.Timesheet.Group.Model;
using RLZZ.Timesheet.Group.Repositories;

namespace RLZZ.Timesheet.Group.Services;

public class GroupService(IGroupRepository groupRepository, ICommandor commandor) : IGroupService
{
    public async Task<List<GroupDto>> ListGroupsAsync(GetAllGroupCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IGroupService>(cancellationToken);
        
        var groups = await groupRepository.ListAllAsync();
        return groups.Select(e => new GroupDto(
            e.GroupId,
            e.Name
        )).ToList();
    }

    public async Task<GroupDto> GetGroupByIdAsync(GetGroupByIdCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IGroupService>(cancellationToken);
        
        var group = await groupRepository.GetByIdAsync(command.Id);
        return new GroupDto(group.GroupId, group.Name);
    }

    public async Task<GroupDto> AddGroupAsync(CreateGroupCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IGroupService>(cancellationToken);
        
        Model.Group groupData = new Model.Group(command.Group.Name);
        
        await groupRepository.AddAsync(groupData);
        return new GroupDto(command.Group.GroupId, groupData.Name);
    }

    public async Task<bool> UpdateGroupAsync(UpdateGroupCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IGroupService>(cancellationToken);
        
        Model.Group updatedGroup = await  groupRepository.GetByIdAsync(command.Group.GroupId);
        updatedGroup.UpdateName(command.Group.Name);
        await groupRepository.UpdateAsync(updatedGroup);
        
        return true;
    }

    public async Task<bool> DeleteGroupAsync(DeleteGroupCommand command, CancellationToken cancellationToken = default)
    {
        await commandor.InvalidateAsync<IGroupService>(cancellationToken);
        
        Model.Group delGroup = await groupRepository.GetByIdAsync(command.Id);
        delGroup.UpdateDeletedFlag(true);
        await groupRepository.UpdateAsync(delGroup);
        return true;
    }
}