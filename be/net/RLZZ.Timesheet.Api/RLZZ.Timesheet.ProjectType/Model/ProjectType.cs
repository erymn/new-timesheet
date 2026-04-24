using Ardalis.GuardClauses;
using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.ProjectType.Model;

public class ProjectType
{
    public int Id { get; set; }
    public string ProjectTypeUniqueId { get; set; }
    public string Name { get; set; }
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public ProjectType(string typeName)
    {
        Name = Guard.Against.NullOrEmpty(typeName);
    }

    public void UpdateUniqueId(int id)
    {
        ProjectTypeUniqueId = id.ToUniqueId();
    }

    public void UpdateDeletedFlag(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }
}