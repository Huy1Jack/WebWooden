using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWooden.Areas.Admin.Models;

[Table("tbUser")]
public partial class TbUser
{

    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }
}
