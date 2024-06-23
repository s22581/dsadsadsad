﻿namespace WebApplication1.Models;

public class ClientDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Discount { get; set; }
    public List<SubscriptionDTO> Subscriptions { get; set; }
}