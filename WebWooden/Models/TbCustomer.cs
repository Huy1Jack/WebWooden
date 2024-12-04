using System;
using System.Collections.Generic;

namespace WebWooden.Models;

public partial class TbCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TbOrder> TbOrders { get; set; } = new List<TbOrder>();
}
