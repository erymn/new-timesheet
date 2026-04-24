using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.Holiday.Model;

public class Holiday
{
    public int Id { get; set; }
    public string HolidayUniqueId { get; set; }
    public DateTime HolidayDay { get; set; }
    public string Name { get; set; }
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public Holiday(DateTime holidayDay, string holidayName)
    {
        HolidayDay = holidayDay;
        Name = holidayName;
    }

    public void UpdateUniqueId(int id)
    {
        HolidayUniqueId = id.ToUniqueId();
    }

    public void UpdateDeletedFlag(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }
}