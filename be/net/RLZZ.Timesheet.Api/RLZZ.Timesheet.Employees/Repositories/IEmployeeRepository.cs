namespace RLZZ.Timesheet.Employees.Repositories;

public interface IEmployeeRepository
{
    Task<Model.Employee> GetByIdAsync(int id);
    Task<List<Model.Employee>> ListAllAsync();
    Task AddAsync(Model.Employee employee);
    Task UpdateAsync(Model.Employee employee);
    Task DeleteAsync(Model.Employee employee);
    Task<int> SaveChangesAsync();
}