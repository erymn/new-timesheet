namespace RLZZ.Timesheet.Project.Repositories;

public interface IProjectRepository
{
    Task<Model.Project> GetByIdAsync(int id);
    Task<List<Model.Project>> ListAllAsync();
    Task AddAsync(Model.Project project);
    Task UpdateAsync(Model.Project project);
    Task DeleteAsync(Model.Project project);
    Task<int> SaveChangesAsync();
}