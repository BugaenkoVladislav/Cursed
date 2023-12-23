using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Buy
{
    public int IdBuy { get; set; }

    public DateOnly Date { get; set; }

    public int IdClient { get; set; }

    public int IdEmployee { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual ICollection<Productsbuy> Productsbuys { get; set; } = new List<Productsbuy>();
}
