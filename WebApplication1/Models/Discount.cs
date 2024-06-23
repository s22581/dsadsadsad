using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Discount
{
    public int IdDiscount { get; set; }

    public int Value { get; set; }

    public DateOnly DateFrom { get; set; }

    public DateOnly DateTo { get; set; }

    public int IdClient { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;
}
