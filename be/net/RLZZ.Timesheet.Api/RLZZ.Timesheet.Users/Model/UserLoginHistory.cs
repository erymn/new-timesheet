namespace RLZZ.Timesheet.User.Model;

public class UserLoginHistory
{
    public long Id { get; set; }

    public int UserId { get; set; }
    public DateTime LoginDate { get; set; }
    public DateTime LogoutDate { get; set; }

    public bool IsSuccessLogin { get; set; } = true;
    
}