using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Recommend
{
    public int RecommendId { get; set; }

    public int CustomerId { get; set; }

    public int DealId { get; set; }

    public string RecDescription { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Deal Deal { get; set; } = null!;
}
