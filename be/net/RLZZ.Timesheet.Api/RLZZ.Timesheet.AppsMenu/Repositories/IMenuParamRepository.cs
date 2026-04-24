namespace RLZZ.Timesheet.AppsMenu.Repositories;

public interface IMenuParamRepository
{
    Task<Model.MenuParam> GetByIdAsync(int id);
    Task<List<Model.MenuParam>> ListAllAsync();
    Task AddAsync(Model.MenuParam menuParam);
    Task UpdateAsync(Model.MenuParam menuParam);
    Task DeleteAsync(Model.MenuParam menuParam);
    Task<int> SaveChangesAsync();
}