namespace RLZZ.Timesheet.Securities;

public static class Roles
{
    public const string Admin = "Admin";
    public const string Supervisor = "Supervisor";
    public const string Employee = "Employee";

    public static List<string> AllRoles => new() { Admin, Supervisor, Employee };
}