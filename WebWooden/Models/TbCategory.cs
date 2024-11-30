using System;
using System.Collections.Generic;

namespace WebWooden.Models;

public partial class TbCategory
{
    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public string? SeoTitle { get; set; }

    public string? SeoDescription { get; set; }

    public string? SeoKeywords { get; set; }

    public string? CreatedDate { get; set; }

    public DateTime? CreatedBy { get; set; }

    public string? ModifiedDate { get; set; }

    public DateTime? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }
}
