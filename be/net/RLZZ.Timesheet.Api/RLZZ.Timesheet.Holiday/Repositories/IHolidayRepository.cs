namespace RLZZ.Timesheet.Holiday.Repositories;

public interface IHolidayRepository
{
    Task<Model.Holiday> GetByIdAsync(int id);
    Task<List<Model.Holiday>> ListAllAsync();
    Task AddAsync(Model.Holiday holiday);
    Task UpdateAsync(Model.Holiday holiday);
    Task DeleteAsync(Model.Holiday holiday);
    Task<int> SaveChangesAsync();
}