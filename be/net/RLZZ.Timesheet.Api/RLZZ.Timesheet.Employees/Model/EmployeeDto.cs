namespace RLZZ.Timesheet.Employees.Model;

public record EmployeeDto
{
    public string EmployeeUniqueId { get; set; }
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public EmployeeDto()
    {
    }

    public EmployeeDto(string employeeUniqueId, string userId, string firstName, string lastName) : this()
    {
        EmployeeUniqueId = employeeUniqueId;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }
}