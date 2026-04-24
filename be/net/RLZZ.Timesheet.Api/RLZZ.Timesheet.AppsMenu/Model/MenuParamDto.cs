namespace RLZZ.Timesheet.AppsMenu.Model;

public record MenuParamDto
{
    public int Id { get; set; }
    public string MenuName { get; set; }
    public string MenuRoute { get; set; }

    public MenuParamDto()
    {
    }

    public MenuParamDto(int id, string menuName, string menuRoute) : this()
    {
        Id = id;
        MenuName = menuName;
        MenuRoute = menuRoute;
    }
}