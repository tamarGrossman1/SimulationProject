using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Image
{
    public int ImgId { get; set; }

    public int ProjectId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
