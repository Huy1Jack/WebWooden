using System;
using System.Collections.Generic;

namespace WebWooden.Models;

public partial class TblAdminUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }
}
