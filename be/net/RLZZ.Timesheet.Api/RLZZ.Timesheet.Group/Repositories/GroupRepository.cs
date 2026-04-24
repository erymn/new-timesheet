using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Group.Data;

namespace RLZZ.Timesheet.Group.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly GroupDbContext _context;

    public GroupRepository(GroupDbContext context)
    {
        _context = context;
    }

    public async Task<Model.Group> GetByIdAsync(int id)
    {
        return await _context.Groups.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.Group>> ListAllAsync()
    {
        return await _context.Groups.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.Group group)
    {
        await _context.Groups.AddAsync(group);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.Group group)
    {
        _context.Groups.Update(group);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.Group group)
    {
        group.UpdateDeletedFlag(true);
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}