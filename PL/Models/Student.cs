using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }
}
