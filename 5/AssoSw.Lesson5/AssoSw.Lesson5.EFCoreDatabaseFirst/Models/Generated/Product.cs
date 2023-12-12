using System;
using System.Collections.Generic;

namespace AssoSw.Lesson5.EFCoreDatabaseFirst.Models.Generated;

public partial class Product
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal? Price { get; set; }

    public int QuantityWarehouse { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
