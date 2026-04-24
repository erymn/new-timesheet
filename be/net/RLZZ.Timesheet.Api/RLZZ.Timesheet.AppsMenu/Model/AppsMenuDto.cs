namespace RLZZ.Timesheet.AppsMenu.Model;

public record AppsMenuDto
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public string GroupId { get; set; }
    public string MenuName { get; set; }
    public string? Route { get; set; }

    public AppsMenuDto()
    {
    }

    public AppsMenuDto(int id, int parentId, string groupId, string menuName, string? route) : this()
    {
        Id = id;
        ParentId = parentId;
        GroupId = groupId;
        MenuName = menuName;
        Route = route;
    }
}