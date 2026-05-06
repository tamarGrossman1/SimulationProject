using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int DealId { get; set; }

    public DateTime OrderFinishDate { get; set; }

    public string Status { get; set; } = null!;

    public double Meters { get; set; }

    public int Budget { get; set; }

    public DateTime OrderDate { get; set; }

    public int CustId { get; set; }

    public int ViewPointId { get; set; }

    public virtual Customer Cust { get; set; } = null!;

    public virtual Deal Deal { get; set; } = null!;

    public virtual IllustrationViewPoint ViewPoint { get; set; } = null!;
}
