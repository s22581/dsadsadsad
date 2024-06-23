using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Repository;

public interface IClientRepository
{
    Task<Client> GetClientByIdAsync(int clientId);
}