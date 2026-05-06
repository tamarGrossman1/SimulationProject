using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Project
{
    public int Id { get; set; }

    public string? Image { get; set; }

    public DateTime? FinalDate { get; set; }

    public string? CompNameCustName { get; set; }

    public int? PackageId { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual Deal? Package { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
