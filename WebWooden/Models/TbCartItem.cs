using System;
using System.Collections.Generic;

namespace WebWooden.Models;

public partial class TbCartItem
{
    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? TotalPrice { get; set; }
}
