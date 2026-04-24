namespace RLZZ.Timesheet.User.Model;

public record UserLoginHistoryDto
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public DateTime LoginDate { get; set; }
    public DateTime LogoutDate { get; set; }
    public bool IsSuccessLogin { get; set; }

    public UserLoginHistoryDto()
    {
    }

    public UserLoginHistoryDto(long id, int userId, DateTime loginDate, DateTime logoutDate, bool isSuccessLogin) : this()
    {
        Id = id;
        UserId = userId;
        LoginDate = loginDate;
        LogoutDate = logoutDate;
        IsSuccessLogin = isSuccessLogin;
    }
}