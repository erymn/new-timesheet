namespace RLZZ.Timesheet.User.Model;

public record UserDto
{
    public string UserUniqueId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string SpvId { get; set; }
    public bool IsForceResetPassword { get; set; }

    public UserDto()
    {
        
    }

    public UserDto(string userUniqueId, string username, string email, string spvId, bool isForceResetPassword) : this()
    {
        this.UserUniqueId = userUniqueId;
        this.Username = username;
        this.Email = email;
        this.SpvId = spvId;
        this.IsForceResetPassword = isForceResetPassword;
    }
}