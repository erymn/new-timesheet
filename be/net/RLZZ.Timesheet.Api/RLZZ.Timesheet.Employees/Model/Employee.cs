using Ardalis.GuardClauses;
using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.Employees.Model;

public class Employee
{
    public int Id { get; set; }
    public string EmployeeUniqueId { get; set; }
    public string UserId { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public Employee(string firstName, string lastName, string userId)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName, nameof(FirstName));
        LastName = Guard.Against.NullOrEmpty(lastName, nameof(LastName));
        UserId = Guard.Against.NullOrEmpty(userId, nameof(UserId));
    }

    public void UpdateUniqueId(int id)
    {
        EmployeeUniqueId = id.ToUniqueId();
    }
}