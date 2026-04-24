namespace RLZZ.Timesheet.SystemParameter.Repositories;

public interface ISysParamRepository
{
    Task<Model.SysParam> GetByIdAsync(int id);
    Task<List<Model.SysParam>> ListAllAsync();
    Task AddAsync(Model.SysParam sysParam);
    Task UpdateAsync(Model.SysParam sysParam);
    Task DeleteAsync(Model.SysParam sysParam);
    Task<int> SaveChangesAsync();
}