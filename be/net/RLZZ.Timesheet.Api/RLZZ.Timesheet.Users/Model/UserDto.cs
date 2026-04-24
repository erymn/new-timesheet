namespace RLZZ.Timesheet.User.Model;

public record UserDto
{
    public string UserUniqueId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsForceResetPassword { get; set; }
    public string IpAddressLock { get; set; }
    public string SpvId { get; set; }

    public UserDto()
    {
    }

    public UserDto(string userUniqueId, string username, string email, bool isForceResetPassword, string ipAddressLock, string spvId) : this()
    {
        UserUniqueId = userUniqueId;
        Username = username;
        Email = email;
        IsForceResetPassword = isForceResetPassword;
        IpAddressLock = ipAddressLock;
        SpvId = spvId;
    }
}