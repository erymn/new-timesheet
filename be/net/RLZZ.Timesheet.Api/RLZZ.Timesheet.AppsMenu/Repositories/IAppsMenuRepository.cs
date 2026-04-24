namespace RLZZ.Timesheet.AppsMenu.Repositories;

public interface IAppsMenuRepository
{
    Task<Model.AppsMenu> GetByIdAsync(int id);
    Task<List<Model.AppsMenu>> ListAllAsync();
    Task AddAsync(Model.AppsMenu appsMenu);
    Task UpdateAsync(Model.AppsMenu appsMenu);
    Task DeleteAsync(Model.AppsMenu appsMenu);
    Task<int> SaveChangesAsync();
}