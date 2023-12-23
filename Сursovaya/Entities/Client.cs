using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Client
{
    public int IdClient { get; set; }

    public string Firstname { get; set; } = null!;

    public string Midname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Buy> Buys { get; set; } = new List<Buy>();
}
