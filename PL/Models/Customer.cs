using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Customer
{
    public int CustomersId { get; set; }

    public string CompNameCustName { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int CustomerType { get; set; }

    public string? ConnectPerson { get; set; }

    public virtual CustemerType CustomerTypeNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Recommend> Recommends { get; set; } = new List<Recommend>();
}
