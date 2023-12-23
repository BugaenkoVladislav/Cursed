using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Provide
{
    public int IdProvide { get; set; }

    public DateOnly Date { get; set; }

    public int IdProvider { get; set; }

    public int IdEmployee { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual ICollection<Productsprovide> Productsprovides { get; set; } = new List<Productsprovide>();
}
