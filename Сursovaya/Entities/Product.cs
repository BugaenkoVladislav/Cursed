using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Productsbuy> Productsbuys { get; set; } = new List<Productsbuy>();

    public virtual ICollection<Productsprovide> Productsprovides { get; set; } = new List<Productsprovide>();
}
