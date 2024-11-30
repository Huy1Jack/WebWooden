using Microsoft.AspNetCore.Mvc;
using WebWooden.Models;


public class BlogViewComponent : ViewComponent
{
	private readonly WoodContext _context;

	public BlogViewComponent(WoodContext context)
	{
		_context = context;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var items = _context.TbBlogs.Where(m => (bool)m.IsActive);

		return await Task.FromResult<IViewComponentResult>
			(View(items.OrderByDescending(m => m.BlogId).ToList()));
	}
}
