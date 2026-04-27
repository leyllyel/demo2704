using System;
using System.Collections.Generic;

namespace Demo2704.Models;

public partial class Manufacturer
{
    public int Manufacturerid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
