namespace RLZZ.Timesheet.Group.Model;

public record GroupDto
{
    public string GroupId { get; set; }
    public string Name { get; set; }

    public GroupDto()
    {
        
    }

    public GroupDto(string groupId, string name) : this()
    {
        this.GroupId = groupId;
        this.Name = name;
    }
}