using System;
using System.Collections.Generic;

namespace Demo2704.Models;

public partial class User
{
    public int Userid { get; set; }

    public string? Usersurname { get; set; }

    public string? Username { get; set; }

    public string? Userpatronymic { get; set; }

    public string? Userlogin { get; set; }

    public string? Userpassword { get; set; }

    public int? Userrole { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? UserroleNavigation { get; set; }
}
