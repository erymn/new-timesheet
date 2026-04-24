using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Task.Data;

namespace RLZZ.Timesheet.Task.Repositories;

public class TsSubmissionRepository : ITsSubmissionRepository
{
    private readonly TaskDbContext _context;

    public TsSubmissionRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<Model.TsSubmission> GetByIdAsync(long id)
    {
        return await _context.Submissions.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.TsSubmission>> ListAllAsync()
    {
        return await _context.Submissions.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async System.Threading.Tasks.Task AddAsync(Model.TsSubmission submission)
    {
        await _context.Submissions.AddAsync(submission);
        await SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task UpdateAsync(Model.TsSubmission submission)
    {
        _context.Submissions.Update(submission);
        await SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task DeleteAsync(Model.TsSubmission submission)
    {
        submission.UpdateDeletedFlag(true);
        _context.Submissions.Update(submission);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}