namespace RLZZ.Timesheet.User.Repositories;

public interface IUserRepository
{
    Task<Model.User> GetByIdAsync(string id);
    Task<Model.User> GetByUsernameAsync(string username);
    Task<List<Model.User>> ListAllAsync();
    Task AddAsync(Model.User user);
    Task UpdateAsync(Model.User user);
    Task DeleteAsync(Model.User user);
    Task<int> SaveChangesAsync();
}