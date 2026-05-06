using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Order1
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int CustId { get; set; }

    public virtual Customer Cust { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
