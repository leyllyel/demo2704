using System;
using System.Collections.Generic;

namespace Demo2704.Models;

public partial class Pickuppoint
{
    public int Pickuppointid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
