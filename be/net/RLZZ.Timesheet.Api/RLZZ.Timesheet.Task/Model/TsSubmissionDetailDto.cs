namespace RLZZ.Timesheet.Task.Model;

public record TsSubmissionDetailDto
{
    public long Id { get; set; }
    public long TsSubmissionId { get; set; }
    public long TsTaskId { get; set; }
    public string ProjectTypeId { get; set; }
    public string ProjectId { get; set; }
    public string Description { get; set; }

    public TsSubmissionDetailDto()
    {
    }

    public TsSubmissionDetailDto(long id, long tsSubmissionId, long tsTaskId, string projectTypeId, string projectId, string description) : this()
    {
        Id = id;
        TsSubmissionId = tsSubmissionId;
        TsTaskId = tsTaskId;
        ProjectTypeId = projectTypeId;
        ProjectId = projectId;
        Description = description;
    }
}