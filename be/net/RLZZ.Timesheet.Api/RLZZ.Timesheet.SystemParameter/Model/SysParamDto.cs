namespace RLZZ.Timesheet.SystemParameter.Model;

public record SysParamDto
{
    public string SysParamUniqueId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public SysParamDto()
    {
    }

    public SysParamDto(string sysParamUniqueId, string code, string name, string type, string description) : this()
    {
        SysParamUniqueId = sysParamUniqueId;
        Code = code;
        Name = name;
        Type = type;
        Description = description;
    }
}