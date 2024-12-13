using System;
using System.Collections.Generic;

namespace WebWooden.Models;

public partial class TbCartItem
{
    public int CartItemId { get; set; }

    public int? ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? AddedDate { get; set; }

    public string? Image { get; set; }

    public virtual TbCustomer? Customer { get; set; }

    public virtual TbProduct? Product { get; set; }
}
