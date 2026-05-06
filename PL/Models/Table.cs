using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Table
{
    public int ImgId { get; set; }

    public int? ProjectId { get; set; }

    public string ImgUrl { get; set; } = null!;

    public virtual Project? Project { get; set; }
}
