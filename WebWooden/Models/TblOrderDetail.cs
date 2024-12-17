﻿using System;
using System.Collections.Generic;

namespace WebWooden.Models;

public partial class TblOrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual TblOrder? Order { get; set; }

    public virtual TblProduct? Product { get; set; }
}
