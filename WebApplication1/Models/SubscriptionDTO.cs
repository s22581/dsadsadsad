namespace WebApplication1.Models;

public class SubscriptionDTO
{
    public int IdSubscription { get; set; }
    public string Name { get; set; }
    public int RenewalPeriod { get; set; }
    public decimal TotalPaidAmount { get; set; }
}