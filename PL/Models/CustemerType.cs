using System;
using System.Collections.Generic;

namespace API.Models;

public partial class CustemerType
{
    public int CustomerTypeId { get; set; }

    public string CustomerType { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
