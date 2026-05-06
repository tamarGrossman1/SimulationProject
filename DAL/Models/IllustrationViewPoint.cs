using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class IllustrationViewPoint
{
    public int IllustrationViewPointId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
