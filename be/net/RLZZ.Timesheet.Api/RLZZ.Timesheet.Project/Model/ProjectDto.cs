namespace RLZZ.Timesheet.Project.Model;

public record ProjectDto
{
    public string ProjectUniqueId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string ClientId { get; set; }
    public decimal Mandays { get; set; }
    public bool IsBillable { get; set; }

    public ProjectDto()
    {
    }

    public ProjectDto(string projectUniqueId, string code, string name, string clientId, decimal mandays, bool isBillable) : this()
    {
        ProjectUniqueId = projectUniqueId;
        Code = code;
        Name = name;
        ClientId = clientId;
        Mandays = mandays;
        IsBillable = isBillable;
    }
}