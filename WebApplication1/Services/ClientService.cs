using WebApplication1.Repository;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    
    public async Task<ClientDTO> GetClientWithSubscriptionsAsync(int clientId)
    {
        var client = await _clientRepository.GetClientByIdAsync(clientId);

        if (client == null)
        {
            return null;
        }

        var now = DateTime.Now;

        var maxDiscount = client.Discounts
            .Where(d => d.DateFrom.ToDateTime(TimeOnly.MinValue) <= now && d.DateTo.ToDateTime(TimeOnly.MinValue) >= now)
            .Max(d => (int?)d.Value) ?? 0;

        var totalDiscount = client.Discounts
            .Where(d => d.DateFrom.ToDateTime(TimeOnly.MinValue) <= now && d.DateTo.ToDateTime(TimeOnly.MinValue) >= now)
            .Sum(d => d.Value);

        if (totalDiscount > 50)
        {
            totalDiscount = 50;
        }

        var clientDTO = new ClientDTO
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone,
            Discount = $"{Math.Max(maxDiscount, totalDiscount)}%",
            Subscriptions = client.Sales.Select(s => new SubscriptionDTO
            {
                IdSubscription = s.IdSubscription,
                Name = s.IdSubscriptionNavigation.Name,
                RenewalPeriod = s.IdSubscriptionNavigation.RenewalPeriod,
                TotalPaidAmount = client.Payments
                    .Where(p => p.IdSubscription == s.IdSubscription)
                    .Sum(p => p.Value)
            }).ToList()
        };

        return clientDTO;
    }
}
