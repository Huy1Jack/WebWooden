using Microsoft.AspNetCore.Mvc;
using WebWooden.Models;


public class NewsViewComponent : ViewComponent
{
	private readonly WoodContext _context;

	public NewsViewComponent(WoodContext context)
	{
		_context = context;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var items = _context.tbblog.Where(m => (bool)m.IsActive);

		return await Task.FromResult<IViewComponentResult>
			(View(items.OrderByDescending(m => m.NewId).ToList()));
	}
}
