using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Services;

public interface IClientService 
{
    Task<ClientDTO> GetClientWithSubscriptionsAsync(int clientIdid);

}