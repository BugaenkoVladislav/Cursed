using System;
using System.Collections.Generic;

namespace Сursovaya.Entities;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string Firstname { get; set; } = null!;

    public string Midname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Buy> Buys { get; set; } = new List<Buy>();

    public virtual ICollection<Provide> Provides { get; set; } = new List<Provide>();
}
