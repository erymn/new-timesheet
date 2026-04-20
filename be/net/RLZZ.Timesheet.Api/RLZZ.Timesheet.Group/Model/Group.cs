namespace RLZZ.Timesheet.Group.Model;

public class Group
{
    public int Id { get; set; }
    public required string GroupId { get; set; }
    public required string Name { get; set; }

    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public required string CreatedBy { get; set; } = "system";
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public required string ModifiedBy { get; set; } = "system";
}