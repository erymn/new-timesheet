using System.Runtime.Serialization;

namespace RLZZ.Timesheet.Task.Model;

public class TsTask
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
    
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedDate { get; private set; } = DateTime.Now;
    public string CreatedBy { get; private set; } = "system";
    public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    public string ModifiedBy { get; private set; } = "system";

    public TsTask(string userName, string password, string salt, string email, bool isForceResetPassword, string supervisorId)
    {
        
    }


}