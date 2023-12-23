using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Provider
{
    public int IdProvider { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Provide> Provides { get; set; } = new List<Provide>();
}
