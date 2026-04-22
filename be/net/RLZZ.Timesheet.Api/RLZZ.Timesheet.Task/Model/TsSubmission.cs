namespace RLZZ.Timesheet.Task.Model;

public class TsSubmission
{
    public long Id { get; set; }

    public DateTime StartTsDate { get; set; }
    public DateTime EndTsDate { get; set; }

    public string SubmitterMail { get; set; }
    public DateTime SubmitDate { get; set; }

    public string ApproverName { get; set; }
    
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";
}