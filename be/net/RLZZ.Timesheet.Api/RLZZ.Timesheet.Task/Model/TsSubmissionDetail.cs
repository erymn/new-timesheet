namespace RLZZ.Timesheet.Task.Model;

public class TsSubmissionDetail
{
    public long Id { get; set; }
    public long  TsSubmissionId { get; set; }

    public long TsTaskId { get; set; }
    public string ProjectTypeId { get; set; }
    public string ProjectId { get; set; }
    public string Description { get; set; }
}