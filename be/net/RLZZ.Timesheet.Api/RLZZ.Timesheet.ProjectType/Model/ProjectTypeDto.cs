namespace RLZZ.Timesheet.ProjectType.Model;

public record ProjectTypeDto
{
    public string ProjectTypeUniqueId { get; set; }
    public string Name { get; set; }

    public ProjectTypeDto()
    {
    }

    public ProjectTypeDto(string projectTypeUniqueId, string name) : this()
    {
        ProjectTypeUniqueId = projectTypeUniqueId;
        Name = name;
    }
}