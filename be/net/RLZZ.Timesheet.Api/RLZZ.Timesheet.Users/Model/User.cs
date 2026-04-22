using Ardalis.GuardClauses;
using RLZZ.Timesheet.Securities;

namespace RLZZ.Timesheet.User.Model;

public class User
{
    public int Id { get; set; }
    public string UserUniqueId { get; set; }
    
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Email { get; set; }

    public bool IsForceResetPassword { get; set; } = true;
    public string IpAddressLock { get; set; }

    public string SpvId { get; set; }
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public User(string userName, string password, string salt, string email, bool isForceResetPassword, string supervisorId)
    {
        Username = Guard.Against.NullOrEmpty(userName, nameof(Username));
        Salt = Guid.NewGuid().ToString();
        Password = PasswordHasher.HashPassword(password, salt);
        Email = Guard.Against.NullOrEmpty(email, nameof(Email));
        IsForceResetPassword = isForceResetPassword;
        SpvId = supervisorId;
    }

    public void UpdateUniqueId(int id)
    {
        UserUniqueId = Id.ToUniqueId();
    }
}