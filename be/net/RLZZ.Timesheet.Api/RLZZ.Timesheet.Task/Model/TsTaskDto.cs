namespace RLZZ.Timesheet.Task.Model;

public record TsTaskDto
{
    public long Id { get; set; }
    public string ProjectTypeId { get; set; }
    public string ProjectId { get; set; }
    public string UserId { get; set; }
    public string Description { get; set; }
    public byte SubmissionStatus { get; set; }
    public DateTime? SubmitDate { get; set; }
    public DateTime ApprovalDate { get; set; }
    public string ApprovalName { get; set; }

    public TsTaskDto()
    {
    }

    public TsTaskDto(long id, string projectTypeId, string projectId, string userId, string description, byte submissionStatus, DateTime? submitDate, DateTime approvalDate, string approvalName) : this()
    {
        Id = id;
        ProjectTypeId = projectTypeId;
        ProjectId = projectId;
        UserId = userId;
        Description = description;
        SubmissionStatus = submissionStatus;
        SubmitDate = submitDate;
        ApprovalDate = approvalDate;
        ApprovalName = approvalName;
    }
}