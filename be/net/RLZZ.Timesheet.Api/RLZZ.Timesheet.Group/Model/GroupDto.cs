namespace RLZZ.Timesheet.Group.Model;

public record GroupDto
{
    public string GroupUniqueId { get; set; }
    public string Name { get; set; }

    public GroupDto()
    {
    }

    public GroupDto(string groupUniqueId, string name) : this()
    {
        GroupUniqueId = groupUniqueId;
        Name = name;
    }
}