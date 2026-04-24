namespace RLZZ.Timesheet.Holiday.Model;

public record HolidayDto
{
    public string HolidayUniqueId { get; set; }
    public DateTime HolidayDay { get; set; }
    public string Name { get; set; }

    public HolidayDto()
    {
    }

    public HolidayDto(string holidayUniqueId, DateTime holidayDay, string name) : this()
    {
        HolidayUniqueId = holidayUniqueId;
        HolidayDay = holidayDay;
        Name = name;
    }
}