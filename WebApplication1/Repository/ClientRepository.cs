using WebApplication1.Context;

namespace WebApplication1.Repository;
using WebApplication1.Models;
using  Microsoft.EntityFrameworkCore;
public class ClientRepository : IClientRepository
{
    private readonly S22581Context _context;

    public ClientRepository(S22581Context context)
    {
        _context = context;
    }

    public async Task<Client> GetClientByIdAsync(int clientId)
    {
        return await _context.Clients
            .Include(c => c.Discounts)
            .Include(c => c.Sales)
            .ThenInclude(s => s.IdSubscriptionNavigation)
            .Include(c => c.Payments)
            .FirstOrDefaultAsync(c => c.IdClient == clientId);
    }
   

}