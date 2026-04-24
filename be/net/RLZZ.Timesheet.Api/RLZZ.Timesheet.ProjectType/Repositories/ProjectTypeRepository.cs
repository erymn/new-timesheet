using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.ProjectType.Data;

namespace RLZZ.Timesheet.ProjectType.Repositories;

public class ProjectTypeRepository : IProjectTypeRepository
{
    private readonly ProjectTypeDbContext _context;

    public ProjectTypeRepository(ProjectTypeDbContext context)
    {
        _context = context;
    }

    public async Task<Model.ProjectType> GetByIdAsync(int id)
    {
        return await _context.ProjectTypes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.ProjectType>> ListAllAsync()
    {
        return await _context.ProjectTypes.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.ProjectType projectType)
    {
        await _context.ProjectTypes.AddAsync(projectType);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.ProjectType projectType)
    {
        _context.ProjectTypes.Update(projectType);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.ProjectType projectType)
    {
        projectType.UpdateDeletedFlag(true);
        _context.ProjectTypes.Update(projectType);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}