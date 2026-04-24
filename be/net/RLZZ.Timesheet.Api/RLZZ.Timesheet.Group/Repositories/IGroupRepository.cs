namespace RLZZ.Timesheet.Group.Repositories;

public interface IGroupRepository
{
    Task<Model.Group> GetByIdAsync(int id);
    Task<List<Model.Group>> ListAllAsync();
    Task AddAsync(Model.Group group);
    Task UpdateAsync(Model.Group group);
    Task DeleteAsync(Model.Group group);
    Task<int> SaveChangesAsync();
}