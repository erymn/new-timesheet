namespace RLZZ.Timesheet.Task.Model;

public record TsSubmissionDto
{
    public long Id { get; set; }
    public DateTime StartTsDate { get; set; }
    public DateTime EndTsDate { get; set; }
    public string SubmitterMail { get; set; }
    public DateTime SubmitDate { get; set; }
    public string ApproverName { get; set; }

    public TsSubmissionDto()
    {
    }

    public TsSubmissionDto(long id, DateTime startTsDate, DateTime endTsDate, string submitterMail, DateTime submitDate, string approverName) : this()
    {
        Id = id;
        StartTsDate = startTsDate;
        EndTsDate = endTsDate;
        SubmitterMail = submitterMail;
        SubmitDate = submitDate;
        ApproverName = approverName;
    }
}