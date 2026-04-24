namespace RLZZ.Timesheet.AppsMenu.Model;

public class MenuParam
{
    public int Id { get; set; }
    public string MenuName { get; set; }
    public string MenuRoute { get; set; }
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public void UpdateDeletedFlag(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }
}