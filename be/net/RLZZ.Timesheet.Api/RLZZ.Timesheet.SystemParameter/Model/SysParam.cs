using Ardalis.GuardClauses;
using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.SystemParameter.Model;

public class SysParam
{
    public int Id { get; set; }
    public string SysParamUniqueId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public SysParam(string paramCode, string paramName, string paramType,  string description)
    {
        Code = Guard.Against.NullOrEmpty(paramCode);
        Name = Guard.Against.NullOrEmpty(paramName);
        Type = Guard.Against.NullOrEmpty(paramType);
        Description = description;
    }

    public void UpdateUniqueId(int id)
    {
        SysParamUniqueId = id.ToUniqueId();
    }
}