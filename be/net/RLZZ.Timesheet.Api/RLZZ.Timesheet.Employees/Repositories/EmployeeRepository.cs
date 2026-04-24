using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Employees.Data;

namespace RLZZ.Timesheet.Employees.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<Model.Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.Employee>> ListAllAsync()
    {
        return await _context.Employees.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.Employee employee)
    {
        _context.Employees.Update(employee);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.Employee employee)
    {
        employee.UpdateDeletedFlag(true);
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}