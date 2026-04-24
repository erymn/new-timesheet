namespace RLZZ.Timesheet.Client.Repositories;

public interface IClientRepository
{
    Task<Model.Client> GetByIdAsync(int id);
    Task<List<Model.Client>> ListAllAsync();
    Task AddAsync(Model.Client client);
    Task UpdateAsync(Model.Client client);
    Task DeleteAsync(Model.Client client);
    Task<int> SaveChangesAsync();
}