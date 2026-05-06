using System;
using System.Collections.Generic;

namespace API.Models;

public partial class City
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
