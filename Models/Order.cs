using System;
using System.Collections.Generic;

namespace Demo2704.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public int? Orderstatusid { get; set; }

    public DateTime? Orderdeliverydate { get; set; }

    public int? Orderpickuppointid { get; set; }

    public int? Userid { get; set; }

    public int? Code { get; set; }

    public virtual Pickuppoint? Orderpickuppoint { get; set; }

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Status? Orderstatus { get; set; }

    public virtual User? User { get; set; }
}
