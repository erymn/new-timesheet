using Ardalis.GuardClauses;
using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.Project.Model;

public class Project
{
    public int Id { get; set; }
    public string ProjectUniqueId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string ClientId { get; set; }
    public decimal Mandays { get; set; }
    public bool IsBillable { get; set; } 
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public Project(string projectCode, string projectName, string clientId,  bool isBillable, decimal mandays = 0)
    {
        Code = Guard.Against.NullOrEmpty(projectCode);
        Name = Guard.Against.NullOrEmpty(projectName);
        ClientId = Guard.Against.NullOrEmpty(clientId);
        IsBillable = isBillable;
        Mandays = mandays;
    }

    public void UpdateUniqueId(int id)
    {
        ProjectUniqueId = id.ToUniqueId();
    }
}