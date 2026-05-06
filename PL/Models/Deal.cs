using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Deal
{
    public int DealId { get; set; }

    public string DealDescription { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Recommend> Recommends { get; set; } = new List<Recommend>();
}
