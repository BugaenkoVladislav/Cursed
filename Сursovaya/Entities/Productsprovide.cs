using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Productsprovide
{
    public int IdProvide { get; set; }

    public int IdProduct { get; set; }

    public int Count { get; set; }

    public decimal PriceForOne { get; set; }

    public decimal Sum { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Provide IdProvideNavigation { get; set; } = null!;
}
