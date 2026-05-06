using System;
using System.Collections.Generic;

namespace API.Models;

public partial class OrderDetail
{
    public int OrderDetailsId { get; set; }

    public int OrderId { get; set; }

    public int DealId { get; set; }

    public DateTime OrderFinishDate { get; set; }

    public string? Status { get; set; }

    public double? Meters { get; set; }

    public DateTime? Date { get; set; }

    public string? Budget { get; set; }

    public virtual Deal Deal { get; set; } = null!;
}
