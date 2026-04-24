using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Project.Data;

namespace RLZZ.Timesheet.Project.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ProjectDbContext _context;

    public ProjectRepository(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task<Model.Project> GetByIdAsync(int id)
    {
        return await _context.Projects.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.Project>> ListAllAsync()
    {
        return await _context.Projects.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.Project project)
    {
        await _context.Projects.AddAsync(project);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.Project project)
    {
        _context.Projects.Update(project);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.Project project)
    {
        project.UpdateDeletedFlag(true);
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}