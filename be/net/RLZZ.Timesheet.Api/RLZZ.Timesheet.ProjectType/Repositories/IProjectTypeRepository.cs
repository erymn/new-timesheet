namespace RLZZ.Timesheet.ProjectType.Repositories;

public interface IProjectTypeRepository
{
    Task<Model.ProjectType> GetByIdAsync(string id);
    Task<List<Model.ProjectType>> ListAllAsync();
    Task AddAsync(Model.ProjectType projectType);
    Task UpdateAsync(Model.ProjectType projectType);
    Task DeleteAsync(Model.ProjectType projectType);
    Task<int> SaveChangesAsync();
}