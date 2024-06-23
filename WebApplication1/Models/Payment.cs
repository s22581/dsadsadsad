using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Payment
{
    public int IdPayment { get; set; }

    public DateOnly Date { get; set; }

    public int IdClient { get; set; }

    public int IdSubscription { get; set; }

    public decimal Value { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;
}
