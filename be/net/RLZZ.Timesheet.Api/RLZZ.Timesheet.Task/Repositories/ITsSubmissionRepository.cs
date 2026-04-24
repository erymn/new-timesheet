namespace RLZZ.Timesheet.Task.Repositories;

public interface ITsSubmissionRepository
{
    Task<Model.TsSubmission> GetByIdAsync(long id);
    Task<List<Model.TsSubmission>> ListAllAsync();
    System.Threading.Tasks.Task AddAsync(Model.TsSubmission submission);
    System.Threading.Tasks.Task UpdateAsync(Model.TsSubmission submission);
    System.Threading.Tasks.Task DeleteAsync(Model.TsSubmission submission);
    Task<int> SaveChangesAsync();
}