using System;
using System.Collections.Generic;

namespace WebWooden.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public string? SeoTitle { get; set; }

    public string? SeoDescription { get; set; }

    public string? SeoKeywords { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public int? AccountId { get; set; }

    public bool IsActive { get; set; }

    public virtual TblAccount? Account { get; set; }

    public virtual TblCategory? Category { get; set; }

    public virtual ICollection<TblBlogComment> TblBlogComments { get; set; } = new List<TblBlogComment>();
}
