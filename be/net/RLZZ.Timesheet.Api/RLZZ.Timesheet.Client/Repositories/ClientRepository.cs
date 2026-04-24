using Microsoft.EntityFrameworkCore;
using RLZZ.Timesheet.Client.Data;

namespace RLZZ.Timesheet.Client.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ClientDbContext _context;

    public ClientRepository(ClientDbContext context)
    {
        _context = context;
    }

    public async Task<Model.Client> GetByIdAsync(int id)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Model.Client>> ListAllAsync()
    {
        return await _context.Clients.Where(c => c.IsDeleted == false).ToListAsync();
    }

    public async Task AddAsync(Model.Client client)
    {
        await _context.Clients.AddAsync(client);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(Model.Client client)
    {
        _context.Clients.Update(client);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Model.Client client)
    {
        client.UpdateDeletedFlag(true);
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}