using Ardalis.GuardClauses;
using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.Group.Model;

public class Group
{
    public int Id { get; private set; }
    public string GroupId { get; private set; }
    public  string Name { get; private set; }

    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public Group(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }
    
    public void UpdateGroupId(int id)
    {
        GroupId = Id.ToUniqueId();
    }

    public void UpdateName(string name)
    {
        Name = Ardalis.GuardClauses.Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }

    public void UpdateDeletedFlag(bool isDeleted)
    {
        IsActive = !isDeleted;
        IsDeleted = isDeleted;
    }
}