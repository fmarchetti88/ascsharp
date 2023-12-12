using System;
using System.Collections.Generic;

namespace AssoSw.Lesson5.EFCoreDatabaseFirst.Models.Generated;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
