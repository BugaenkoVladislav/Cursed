using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Productsbuy
{
    public int IdBuy { get; set; }

    public int IdProduct { get; set; }

    public int Count { get; set; }

    public decimal Price { get; set; }

    public decimal Sum { get; set; }

    public virtual Buy IdBuyNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
