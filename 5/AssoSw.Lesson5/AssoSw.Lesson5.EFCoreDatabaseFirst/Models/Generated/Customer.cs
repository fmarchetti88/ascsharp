using System;
using System.Collections.Generic;

namespace AssoSw.Lesson5.EFCoreDatabaseFirst.Models.Generated;

public partial class Customer
{
    public int Id { get; set; }

    public string BusinessName { get; set; } = null!;

    public string? VatCode { get; set; }

    public string? FiscalCode { get; set; }

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
