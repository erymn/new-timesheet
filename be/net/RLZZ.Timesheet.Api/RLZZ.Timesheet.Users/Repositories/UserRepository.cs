using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.User.Data;

namespace RLZZ.Timesheet.User.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<Model.User> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.User>> ListAllAsync()
    {
        return await _context.Users.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.User user)
    {
        await _context.Users.AddAsync(user);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.User user)
    {
        _context.Users.Update(user);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.User user)
    {
        user.UpdateDeletedFlag(true);
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}