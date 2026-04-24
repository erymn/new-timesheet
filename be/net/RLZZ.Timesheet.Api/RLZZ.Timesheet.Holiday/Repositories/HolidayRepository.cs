using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Holiday.Data;

namespace RLZZ.Timesheet.Holiday.Repositories;

public class HolidayRepository : IHolidayRepository
{
    private readonly HolidayDbContext _context;

    public HolidayRepository(HolidayDbContext context)
    {
        _context = context;
    }

    public async Task<Model.Holiday> GetByIdAsync(int id)
    {
        return await _context.Holidays.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.Holiday>> ListAllAsync()
    {
        return await _context.Holidays.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.Holiday holiday)
    {
        await _context.Holidays.AddAsync(holiday);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.Holiday holiday)
    {
        _context.Holidays.Update(holiday);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.Holiday holiday)
    {
        holiday.UpdateDeletedFlag(true);
        _context.Holidays.Update(holiday);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}