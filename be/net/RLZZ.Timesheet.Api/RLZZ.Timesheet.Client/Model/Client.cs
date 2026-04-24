using Ardalis.GuardClauses;
using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.Client.Model;

public class Client
{
    public int Id { get; set; }
    public string ClientUniqueId { get; set; }
    public string Name { get; set; }
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public Client(string clientName)
    {
        Name = Guard.Against.NullOrEmpty(clientName);
    }

    public void UpdateUniqueId(int id)
    {
        ClientUniqueId = id.ToUniqueId();
    }

    public void UpdateDeletedFlag(bool isDeleted)
    {
        IsDeleted = isDeleted;
    }
}